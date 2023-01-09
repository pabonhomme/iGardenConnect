#define INPUT_PIN A0
#define PUMP_PIN A1

bool flag = true;
int rawADC;
 
void setup() { 
    Serial.begin(9600);
    pinMode(INPUT_PIN,INPUT);
    pinMode(PUMP_PIN,OUTPUT);
    digitalWrite(PUMP_PIN,0);
}
 
void loop() { 
  rawADC = analogRead(INPUT_PIN);
  Serial.println(rawADC);
  if(rawADC>370){
      digitalWrite(PUMP_PIN,1);
      Serial.println("Pompe activee");
  }

  else
    digitalWrite(PUMP_PIN,0);
  delay(100);
}