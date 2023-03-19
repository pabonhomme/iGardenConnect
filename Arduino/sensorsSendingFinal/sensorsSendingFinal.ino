#include <FastLED.h>
#include <Grove_LED_Bar.h>
#include <Wire.h>
#include "DHT.h"       //Temperature&Humidity
#include <WiFiNINA.h>  //sending

#ifdef ARDUINO_SAMD_VARIANT_COMPLIANCE
#define SERIAL SerialUSB
#else
#define SERIAL Serial
#endif

unsigned char low_data[8] = { 0 };
unsigned char high_data[12] = { 0 };

//Temperature&Humidity
#define DHTPIN 5
#define DHTTYPE DHT11

#define NO_TOUCH 0xFE
#define THRESHOLD 100
#define ATTINY1_HIGH_ADDR 0x78
#define ATTINY2_LOW_ADDR 0x77
//------------LEDS------------
// How many leds in your strip?
#define NUM_LEDS1 166
#define NUM_LEDS2 166
int relay_3 = 8;
int relay_4 = 12;
#define DATA_PIN1 13
#define DATA_PIN2 6
#define CLOCK_PIN 13
#define UPDATES_PER_SECOND 100
CRGB leds1[NUM_LEDS1];
CRGB leds2[NUM_LEDS2];
//---------------light sensor
Grove_LED_Bar bar(3, 2, 0, 10);

//----------------soil
int relay_2 = 7;
int soilMoistureValue = 0;
int pumpTime = 0;

//----------------Sending
const char* ssid = "xxxxxxxxxxx";
const char* password = "xxxxx";



void getHigh12SectionValue(void) {
  memset(high_data, 0, sizeof(high_data));
  Wire.requestFrom(ATTINY1_HIGH_ADDR, 12);
  while (12 != Wire.available())
    ;

  for (int i = 0; i < 12; i++) {
    high_data[i] = Wire.read();
  }
  delay(10);
}

void getLow8SectionValue(void) {
  memset(low_data, 0, sizeof(low_data));
  Wire.requestFrom(ATTINY2_LOW_ADDR, 8);
  while (8 != Wire.available())
    ;

  for (int i = 0; i < 8; i++) {
    low_data[i] = Wire.read();  // receive a byte as character
  }
  delay(10);
}

int check() {
  int sensorvalue_min = 250;
  int sensorvalue_max = 255;
  int low_count = 0;
  int high_count = 0;

  uint32_t touch_val = 0;
  uint8_t trig_section = 0;
  low_count = 0;
  high_count = 0;
  getLow8SectionValue();
  getHigh12SectionValue();

  for (int i = 0; i < 8; i++) {
    if (low_data[i] >= sensorvalue_min && low_data[i] <= sensorvalue_max) {
      low_count++;
    }
  }

  for (int i = 0; i < 12; i++) {
    if (high_data[i] >= sensorvalue_min && high_data[i] <= sensorvalue_max) {
      high_count++;
    }
  }

  for (int i = 0; i < 8; i++) {
    if (low_data[i] > THRESHOLD) {
      touch_val |= 1 << i;
    }
  }
  for (int i = 0; i < 12; i++) {
    if (high_data[i] > THRESHOLD) {
      touch_val |= (uint32_t)1 << (8 + i);
    }
  }

  while (touch_val & 0x01) {
    trig_section++;
    touch_val >>= 1;
  }
  SERIAL.print("water level = ");
  SERIAL.print(trig_section * 5);
  SERIAL.println(" %");
  SERIAL.println("------------------------------------------");
  delay(1000);
  return trig_section * 5;
}

//Temperature&Humidity
DHT dht(DHTPIN, DHTTYPE);

int pump_send = 0;
bool LEDstate = 0;
bool PUMPstate = 0;

void setup() {
  Serial.begin(9600);  // open serial port, set the baud rate to 9600 bps
  //-------------------Sending
  delay(10);
  while (!Serial)
    ;

  // Connexion au réseau WiFi
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.println("Connexion au reseau WiFi...");
    delay(1000);
  }
  Serial.println("Connecte au reseau WiFi");


  Serial.println("");
  Serial.println("Adresse IP: ");
  Serial.println(WiFi.localIP());

  // Connexion au serveur
  Serial.println();

  //-----------------------END_SENDING




  pinMode(relay_2, OUTPUT);
  //WATER LEVEL
  Wire.begin();
  //lightsensor
  bar.begin();
  pinMode(relay_3, OUTPUT);
  pinMode(relay_4, OUTPUT);
  FastLED.addLeds<NEOPIXEL, DATA_PIN1>(leds1, NUM_LEDS1);
  FastLED.addLeds<NEOPIXEL, DATA_PIN2>(leds2, NUM_LEDS2);

  dht.begin();  //Temperature&Humidity
}


void loop() {
  SERIAL.println("*********************************************************");
  SERIAL.println("*******************Nouvelles Mesures*********************");
  SERIAL.println("*********************************************************");
  Serial.println("Temperature = " + String(dht.readTemperature()) + " C");
  Serial.println("Humidite = " + String(dht.readHumidity()) + " %");
  soilMoistureValue = analogRead(A4);  //put Sensor insert into soil
  Serial.println(soilMoistureValue);
  if (soilMoistureValue > 380) {
    Serial.println("Dry");
    Serial.println(soilMoistureValue);
    digitalWrite(relay_2, HIGH);
    PUMPstate = 1;
    if (pumpTime == 0) {
      pumpTime = millis();
    }
  } else if (soilMoistureValue <= 379) {
    Serial.println("Wet");
    digitalWrite(relay_2, LOW);
    if (pumpTime < 0) {
      pumpTime = pumpTime * -1;
    }
    Serial.println("Temps Pompe Active : " + String(pumpTime / 1000) + " secondes");
    pump_send = pumpTime / 1000;
    pumpTime = 0;
    PUMPstate = 0;
  }
  //light sensor
  int value = analogRead(A0);
  value = map(value, 0, 800, 0, 10);
  bar.setLevel(value);
  Serial.println("Luminosité = " + String(value));
  delay(100);
  if (value < 2) {
    digitalWrite(relay_3, HIGH);
    digitalWrite(relay_4, HIGH);
    if (digitalRead(relay_3) == HIGH && digitalRead(relay_4) == HIGH) {
      Serial.println("Bandeau LED1: Relay 3 ON");
      Serial.println("Bandeau LED2: Relay 4 ON");
      for (int i = 0; i < 166; i++) {
        leds1[i] = CRGB::Blue;
        leds2[i] = CRGB::Blue;
        FastLED.show();
      }
      LEDstate = 1;
    }
  } else {
    digitalWrite(relay_3, LOW);
    digitalWrite(relay_4, LOW);
    Serial.println("Bandeau LED1 & LED2: Relay 4 & 5 OFF");
    LEDstate = 0;
  }
  int return_water_level = check();
  delay(3000);



  //-----------------------Sending
  char server[] = "192.168.104.59";

  //TEMPERATURE
  char endpointTemperature[] = "/api/GardenSensor/g01/1/";
  String temperature = String(dht.readTemperature());
  String sendTemperature = String(endpointTemperature) + String(temperature);

  WiFiClient client;
  if (client.connect(server, 5241)) {
    Serial.println("Liaison Effectuée à la route Temperature: " + sendTemperature);
    client.print("PUT " + String(sendTemperature) + " HTTP/1.1\r\n");
    client.print("Host: localhost:5241\r\n");
    client.print("User-Agent: Arduino/1.0\r\n");
    client.print("Accept: text/plain\r\n");
    client.print("Content-Length: 0\r\n");
    client.print("Connection: close\r\n\r\n");
  } else {
    Serial.println("echec");
    Serial.println(client.connect(server, 5241));
  }

  //HUMIDITY
  char endpointHumidity[] = "/api/GardenSensor/g01/2/";
  String humidity = String(dht.readHumidity());
  String sendHumidity = String(endpointHumidity) + String(humidity);
  if (client.connect(server, 5241)) {
    Serial.println("Liaison Effectuée à la route Humidity: " + sendHumidity);
    client.print("PUT " + String(sendHumidity) + " HTTP/1.1\r\n");
    client.print("Host: localhost:5241\r\n");
    client.print("User-Agent: Arduino/1.0\r\n");
    client.print("Accept: text/plain\r\n");
    client.print("Content-Length: 0\r\n");
    client.print("Connection: close\r\n\r\n");
  } else {
    Serial.println("echec");
    Serial.println(client.connect(server, 5241));
  }

  //SOIL_HUMIDITY
  char endpointSoilHumidity[] = "/api/GardenSensor/g01/3/";
  String soil_humidity = String(soilMoistureValue);
  String sendSoilHumidity = String(endpointSoilHumidity) + String(soil_humidity);
  if (client.connect(server, 5241)) {
    Serial.println("Liaison Effctuée à la route Soil_Humidity: " + sendSoilHumidity);
    client.print("PUT " + String(sendSoilHumidity) + " HTTP/1.1\r\n");
    client.print("Host: localhost:5241\r\n");
    client.print("User-Agent: Arduino/1.0\r\n");
    client.print("Accept: text/plain\r\n");
    client.print("Content-Length: 0\r\n");
    client.print("Connection: close\r\n\r\n");
  } else {
    Serial.println("echec");
    Serial.println(client.connect(server, 5241));
  }

  //water_level
  char endpointwater_level[] = "/api/GardenSensor/g01/4/";
  String water_level = String(return_water_level);
  String sendwater_level = String(endpointwater_level) + String(water_level);
  if (client.connect(server, 5241)) {
    Serial.println("Liaison Effectuée à la route Water_level: " + sendwater_level);
    client.print("PUT " + String(sendwater_level) + " HTTP/1.1\r\n");
    client.print("Host: localhost:5241\r\n");
    client.print("User-Agent: Arduino/1.0\r\n");
    client.print("Accept: text/plain\r\n");
    client.print("Content-Length: 0\r\n");
    client.print("Connection: close\r\n\r\n");
  } else {
    Serial.println("echec");
    Serial.println(client.connect(server, 5241));
  }

  //Brightness
  char endpointBrightness[] = "/api/GardenSensor/g01/5/";
  String sendBrightness = String(endpointBrightness) + String(value);
  if (client.connect(server, 5241)) {
    Serial.println("Liaison Effectuée à la route Brightness: " + sendBrightness);
    client.print("PUT " + String(sendBrightness) + " HTTP/1.1\r\n");
    client.print("Host: localhost:5241\r\n");
    client.print("User-Agent: Arduino/1.0\r\n");
    client.print("Accept: text/plain\r\n");
    client.print("Content-Length: 0\r\n");
    client.print("Connection: close\r\n\r\n");
  } else {
    Serial.println("echec");
    Serial.println(client.connect(server, 5241));
  }

  //PUMP
  char endpointPUMPstate[] = "/api/Garden/g01/";
  String sendPUMPstate = String(endpointPUMPstate) + String(PUMPstate);
  if (client.connect(server, 5241)) {
    Serial.println("Liaison Effectuée à la route Pump_State: " + sendPUMPstate);
    client.print("PUT " + String(sendPUMPstate) + " HTTP/1.1\r\n");
    client.print("Host: localhost:5241\r\n");
    client.print("User-Agent: Arduino/1.0\r\n");
    client.print("Accept: text/plain\r\n");
    client.print("Content-Length: 0\r\n");
    client.print("Connection: close\r\n\r\n");
  } else {
    Serial.println("echec");
    Serial.println(client.connect(server, 5241));
  }

  //LEDS
  char endpointLEDstate[] = "/api/GardenSensor/g01/7/";
  String sendLEDstate = String(endpointLEDstate) + String(LEDstate);
  if (client.connect(server, 5241)) {
    Serial.println("Liaison Effectuée à la route Leds_state: " + sendLEDstate);
    client.print("PUT " + String(sendLEDstate) + " HTTP/1.1\r\n");
    client.print("Host: localhost:5241\r\n");
    client.print("User-Agent: Arduino/1.0\r\n");
    client.print("Accept: text/plain\r\n");
    client.print("Content-Length: 0\r\n");
    client.print("Connection: close\r\n\r\n");
  } else {
    Serial.println("echec");
    Serial.println(client.connect(server, 5241));
  }

  //water_pump_time
  if (PUMPstate == 0) {
    char endpointwater_pump_time[] = "/api/Garden/g01/6/";
    String water_pump_time = String(pump_send);
    String sendwater_pump_time = String(endpointwater_pump_time) + String(water_pump_time);
    if (client.connect(server, 5241)) {
      Serial.println("Liaison Effectuée à la route Water_pump_time: " + sendwater_pump_time);
      client.print("PUT " + String(sendwater_pump_time) + " HTTP/1.1\r\n");
      client.print("Host: localhost:5241\r\n");
      client.print("User-Agent: Arduino/1.0\r\n");
      client.print("Accept: text/plain\r\n");
      client.print("Content-Length: 0\r\n");
      client.print("Connection: close\r\n\r\n");
    } else {
      Serial.println("echec");
      Serial.println(client.connect(server, 5241));
    }
  }

  SERIAL.println(" ");
  SERIAL.println(" ");


  //delaySending
  if (PUMPstate == 1) {
    delay(3000);
  } else {
    delay(15000);
  }
}