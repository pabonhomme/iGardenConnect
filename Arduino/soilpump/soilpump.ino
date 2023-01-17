int relay_2 = 7;
int soilMoistureValue = 0;
void setup() {
  Serial.begin(9600); // open serial port, set the baud rate to 9600 bps
  pinMode(relay_2, OUTPUT);
}
void loop() {
  soilMoistureValue = analogRead(A0);  //put Sensor insert into soil
  if(soilMoistureValue > 380 )
  {
    Serial.println("Dry");
    digitalWrite(relay_2, HIGH);
    Serial.println("All relays ON");    
  }
    else if(soilMoistureValue <380 )
    {
      Serial.println("Wet");
      digitalWrite(relay_2, LOW);
    Serial.println("All relays OFF");
    }
    delay(1000);
  }