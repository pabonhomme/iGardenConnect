int relay_2 = 7;


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  pinMode(relay_2, OUTPUT);

}

void loop() {
  digitalWrite(relay_2, HIGH);
  Serial.println("All relays ON");
  delay(1000);
  digitalWrite(relay_2, LOW);
  Serial.println("All relays OFF");

  delay(1000);
}