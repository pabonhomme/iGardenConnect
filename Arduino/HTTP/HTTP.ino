#include <SPI.h>
#include <WiFiNINA.h>
#include "DHT.h"

#define DHTPIN A2
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);

char ssid[] = "AndroidAP7746";        // your network SSID (name)
char pass[] = "eliotvincent"; 
int keyIndex = 0;

int status = WL_IDLE_STATUS;
WiFiServer server(80);


void setup() {
  Serial.begin(9600);
  dht.begin();
  while (!Serial);

  while (status != WL_CONNECTED) {
    Serial.print("Attempting to connect to Network named: ");
    Serial.println(ssid);
    status = WiFi.begin(ssid, pass);
    delay(10000);
  }
  server.begin();

  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);
}

void loop() {

  
  float h =dht.readHumidity();
  // Read temperature as Celsius
  float t = dht.readTemperature();
  WiFiClient client = server.available();   
  if (client) {                             
    Serial.println("new client");           
    String currentLine = "";                
    while (client.connected()) {            
      if (client.available()) {             
        char c = client.read();             
        Serial.write(c);                    
        if (c == '\n') {                    

          if (currentLine.length() == 0) {
           client.println("<head><meta http-equiv=\"refresh\" content=\"5\"></head>");
            client.print("<h1 style=\"color:green; font-size:80px\">");
            client.print("temperature:");
            client.print(t);
            client.println("</h1>");
            client.print("<h1 style=\"color:green; font-size:80px\">");
            client.print("humidite :");
            client.print(h);
            client.println("</h1>");
            break;
          }else {
            currentLine = "";
          }
      
        } else if (c != '\r') {
          currentLine += c;
        }
      }
    }

    client.stop();
    Serial.println("client disconnected");
  }
}
