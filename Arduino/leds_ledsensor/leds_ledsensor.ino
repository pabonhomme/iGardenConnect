#include <FastLED.h>
#include <Grove_LED_Bar.h>

// How many leds in your strip?
#define NUM_LEDS1 166
#define NUM_LEDS2 166
int relay_3 = 8;
int relay_4 = 12;
#define DATA_PIN1 2
#define DATA_PIN2 7
#define CLOCK_PIN 13
#define UPDATES_PER_SECOND 100
CRGB leds1[NUM_LEDS1];
CRGB leds2[NUM_LEDS2];
//light sensor
Grove_LED_Bar bar(3, 2, 0, 10); // Clock pin, Data pin, Orientation
 

void setup() {
  //lightsensor
  bar.begin();
  pinMode(relay_3, OUTPUT);
  pinMode(relay_4, OUTPUT);
  FastLED.addLeds<NEOPIXEL, DATA_PIN1>(leds1, NUM_LEDS1); 
  FastLED.addLeds<NEOPIXEL, DATA_PIN2>(leds2, NUM_LEDS2); 

}

void loop() {
  //light sensor
  int value = analogRead(A0);
  value = map(value, 0, 800, 0, 10);
  bar.setLevel(value);
  delay(100);
  if(value<4){
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
  if(digitalRead(relay_4)==HIGH){
    Serial.println("relay 4 ON");
    for(int i=0;i<166;i++){
    leds2[i] = CRGB::Blue;
    FastLED.show();
    //FastLED.delay(1000 / UPDATES_PER_SECOND);
    }
    }
  // delay(1000);
    }  
  //lights  
  }
  else{
    digitalWrite(relay_3, LOW);
    digitalWrite(relay_4, LOW);
  }
  
}