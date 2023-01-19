#include <Grove_LED_Bar.h>

Grove_LED_Bar bar(3, 2, 0, 10); // Clock pin, Data pin, Orientation
 
void setup()
{
  // nothing to initialize
  bar.begin();
  // bar.setGreenToRed(true);
}
 
void loop()
{
  int value = analogRead(A0);
  value = map(value, 0, 800, 0, 10);
  bar.setLevel(value);
  delay(100);
}