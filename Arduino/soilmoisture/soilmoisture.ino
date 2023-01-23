
    int soilMoistureValue = 0;
    void setup() {
      Serial.begin(9600); // open serial port, set the baud rate to 9600 bps
    }
    void loop() {
    soilMoistureValue = analogRead(A0);  //put Sensor insert into soil
    if(soilMoistureValue > 380 )
    {
      Serial.println("Dry");
    }
    else if(soilMoistureValue <380 )
    {
      Serial.println("Wet");
    }
    delay(1000);
  }