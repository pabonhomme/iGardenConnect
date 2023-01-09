#include <Wire.h>


//NIVDEAU
#ifdef ARDUINO_SAMD_VARIANT_COMPLIANCE
#define SERIAL SerialUSB
#else
#define SERIAL Serial
#endif
 
unsigned char low_data[8] = {0};
unsigned char high_data[12] = {0};
//

#define INPUT_PIN A0
#define PUMP_PIN A1

//NIVDEAU
#define NO_TOUCH       0xFE
#define THRESHOLD      100
#define ATTINY1_HIGH_ADDR   0x78
#define ATTINY2_LOW_ADDR   0x77
//


bool flag = true;
int rawADC;

//NIVDEAU
void getHigh12SectionValue(void)
{
  memset(high_data, 0, sizeof(high_data));
  Wire.requestFrom(ATTINY1_HIGH_ADDR, 12);
  while (12 != Wire.available());
 
  for (int i = 0; i < 12; i++) {
    high_data[i] = Wire.read();
  }
  delay(100);
}
 
void getLow8SectionValue(void)
{
  memset(low_data, 0, sizeof(low_data));
  Wire.requestFrom(ATTINY2_LOW_ADDR, 8);
  while (8 != Wire.available());
 
  for (int i = 0; i < 8 ; i++) {
    low_data[i] = Wire.read(); // receive a byte as character
  }
  delay(100);
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
    SERIAL.println("*********************************************************");
    delay(1000);
}
//
 
void setup() { 
    Serial.begin(9600);
    pinMode(INPUT_PIN,INPUT);
    pinMode(PUMP_PIN,OUTPUT);
    digitalWrite(PUMP_PIN,0);

    //NIVDEAU
    Wire.begin();
    //
}
 
void loop() { 
  rawADC = analogRead(INPUT_PIN);
  Serial.println(rawADC);
  if(rawADC>=370){
      digitalWrite(PUMP_PIN,1);
      Serial.println("Pompe activee");
  }
  else
    digitalWrite(PUMP_PIN,0);
  delay(1000);
  // Nivdeau
  check();
  delay(1000);


  
}