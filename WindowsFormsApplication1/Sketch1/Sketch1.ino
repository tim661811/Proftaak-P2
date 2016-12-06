/*
 Name:		Sketch1.ino
 Created:	12/6/2016 1:12:32 PM
 Author:	stant
*/

String message = "";
char readChar;
int messageCount = 0;
bool messageStarted = false;


// the setup function runs once when you press reset or power the board
void setup() {

}

// the loop function runs over and over again until power down or reset
void loop() {
  
	messaging();


}

////////////////////////////////////////////////////////////// Methodes ////////////////////////////////////////////////////////////////////////

void messaging()
{
	// deze variabelen zijn nodig

	//String message = "";
	//char readChar;
	//int messageCount = 0;
	//bool messageStarted = false;

	if (Serial.available() > 0)
	{

		// 'Convert' naar char
		readChar = (char)Serial.read();

		if (messageStarted == true)
		{
			if (readChar == '%')
			{
				Serial.print("The last ");
				Serial.print(messageCount);
				Serial.print(" characters I received: ");
				Serial.println(message);
				Serial.println("");
				Serial.println("");
				checkIfMessageEquals();
				reset();
			}
			else
			{
				// zet chars om naar message
				message = message + readChar;
				messageCount = message.length();

			}

		}
		if (readChar == '#')
		{
			messageStarted = true;
			Serial.println("messageStarted is true");
		}
	}
}


// hier wordt gekeken of het ontvangen bericht gelijk is /n
// aan een vastgesteld bericht en vervolgens word er iets uitgevoerd
void checkIfMessageEquals() {
	if (message == "LED_ON")
	{
		digitalWrite(ledPin, HIGH);
	}
	if (message == "LED_OFF")
	{
		digitalWrite(ledPin, LOW);
	}
	if (message == "LED_BLINK")
	{
		blinkLedFiveTimes();
	}
}

void reset() {
	message = "";
	messageCount = 0;
	messageStarted = false;
}