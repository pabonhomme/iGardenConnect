#include <FastLED.h>


#define NUM_LEDS1 166
#define NUM_LEDS2 166

#define DATA_PIN1 2
#define DATA_PIN2 7
#define CLOCK_PIN 13
#define UPDATES_PER_SECOND 100

int relay_2 = 7;
int soilMoistureValue = 0;

CRGB leds1[NUM_LEDS1];
CRGB leds2[NUM_LEDS2];

void setup() {
  Serial.begin(9600); // open serial port, set the baud rate to 9600 bps
  //relay
  pinMode(relay_2, OUTPUT);
  //LEDS
  FastLED.addLeds<NEOPIXEL, DATA_PIN1>(leds1, NUM_LEDS1); 
  FastLED.addLeds<NEOPIXEL, DATA_PIN2>(leds2, NUM_LEDS2); 
}
void loop() {
  //LEDS
  for(int i=0;i<166;i++){
  leds1[i] = CRGB::Blue;
  FastLED.show();
  // FastLED.delay(1000 / UPDATES_PER_SECOND);
  // Now turn the LED off, then pause
  }
  // delay(10);
  for(int i=0;i<166;i++){
  leds2[i] = CRGB::Blue;
  FastLED.show();
  // FastLED.delay(1000 / UPDATES_PER_SECOND);
  // Now turn the LED off, then pause
  }
  
  //soil moisture
  soilMoistureValue = analogRead(A0);  //put Sensor insert into soil
  if(soilMoistureValue > 380 )
  {
    Serial.println("Dry");
    //pump relay
    digitalWrite(relay_2, HIGH);
    Serial.println("All relays ON");    
  }
    else if(soilMoistureValue <380 )
    {
      Serial.println("Wet");
      //relay pump
      digitalWrite(relay_2, LOW);
    Serial.println("All relays OFF");
    }
    delay(1000);
  }