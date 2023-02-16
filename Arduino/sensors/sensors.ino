#include <FastLED.h>
#include <Grove_LED_Bar.h>
#include <Wire.h>
 
#ifdef ARDUINO_SAMD_VARIANT_COMPLIANCE
#define SERIAL SerialUSB
#else
#define SERIAL Serial
#endif
 
unsigned char low_data[8] = {0};
unsigned char high_data[12] = {0};
 
 
#define NO_TOUCH       0xFE
#define THRESHOLD      100
#define ATTINY1_HIGH_ADDR   0x78
#define ATTINY2_LOW_ADDR   0x77
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

void getHigh12SectionValue(void)
{
  memset(high_data, 0, sizeof(high_data));
  Wire.requestFrom(ATTINY1_HIGH_ADDR, 12);
  while (12 != Wire.available());
 
  for (int i = 0; i < 12; i++) {
    high_data[i] = Wire.read();
  }
  delay(10);
}
 
void getLow8SectionValue(void)
{
  memset(low_data, 0, sizeof(low_data));
  Wire.requestFrom(ATTINY2_LOW_ADDR, 8);
  while (8 != Wire.available());
 
  for (int i = 0; i < 8 ; i++) {
    low_data[i] = Wire.read(); // receive a byte as character
  }
  delay(10);
}
 
void check()
{
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
 
    Serial.println("low 8 sections value = ");
    for (int i = 0; i < 8; i++)
    {
      Serial.print(low_data[i]);
      Serial.print(".");
      if (low_data[i] >= sensorvalue_min && low_data[i] <= sensorvalue_max)
      {
        low_count++;
      }
      if (low_count == 8)
      {
        Serial.print("      ");
        Serial.print("PASS");
      }
    }
    Serial.println("  ");
    Serial.println("  ");
    Serial.println("high 12 sections value = ");
    for (int i = 0; i < 12; i++)
    {
      Serial.print(high_data[i]);
      Serial.print(".");
 
      if (high_data[i] >= sensorvalue_min && high_data[i] <= sensorvalue_max)
      {
        high_count++;
      }
      if (high_count == 12)
      {
        Serial.print("      ");
        Serial.print("PASS");
      }
    }
 
    Serial.println("  ");
    Serial.println("  ");
 
    for (int i = 0 ; i < 8; i++) {
      if (low_data[i] > THRESHOLD) {
        touch_val |= 1 << i;
 
      }
    }
    for (int i = 0 ; i < 12; i++) {
      if (high_data[i] > THRESHOLD) {
        touch_val |= (uint32_t)1 << (8 + i);
      }
    }
 
    while (touch_val & 0x01)
    {
      trig_section++;
      touch_val >>= 1;
    }
    SERIAL.print("water level = ");
    SERIAL.print(trig_section * 5);
    SERIAL.println("% ");
    SERIAL.println(" ");
    SERIAL.println("*********************************************************");
    delay(1000);
}


void setup() {
  Serial.begin(9600); // open serial port, set the baud rate to 9600 bps
  pinMode(relay_2, OUTPUT);
//WATER LEVEL
  Wire.begin();
    //lightsensor
  bar.begin();
  pinMode(relay_3, OUTPUT);
  pinMode(relay_4, OUTPUT);
  FastLED.addLeds<NEOPIXEL, DATA_PIN1>(leds1, NUM_LEDS1); 
  FastLED.addLeds<NEOPIXEL, DATA_PIN2>(leds2, NUM_LEDS2); 
}
void loop() {
  soilMoistureValue = analogRead(A4);  //put Sensor insert into soil
  Serial.println(soilMoistureValue);
  if(soilMoistureValue > 515 )
  {
    Serial.println("Dry");
    Serial.println(soilMoistureValue);
    digitalWrite(relay_2, HIGH);
    Serial.println("All relays ON");    
  }
  else if(soilMoistureValue <515 )
  {
    Serial.println("Wet");
    digitalWrite(relay_2, LOW);
    Serial.println("All relays OFF");
  }
    // delay(1000);
  //light sensor
  int value = analogRead(A0);
  value = map(value, 0, 800, 0, 10);
  bar.setLevel(value);
  delay(100);
  if(value<=4){
    digitalWrite(relay_3, HIGH);
    digitalWrite(relay_4, HIGH);
    if(digitalRead(relay_3)==HIGH){
      Serial.println("Relay 3 ON");
    for(int i=0;i<166;i++){
    leds1[i] = CRGB::Blue;
    FastLED.show();
  //FastLED.delay(1000 / UPDATES_PER_SECOND);
  // Now turn the LED off, then pause
  }
  }
  if(digitalRead(relay_4)==HIGH){
    Serial.println("relay 4 ON");
    for(int i=0;i<166;i++){
    leds2[i] = CRGB::Blue;
    FastLED.show();
    //FastLED.delay(1000 / UPDATES_PER_SECOND);
    }
    }
  // delay(1000); 
  //lights  
  }
  else{
    digitalWrite(relay_3, LOW);
    digitalWrite(relay_4, LOW);
  }
  check();
  }