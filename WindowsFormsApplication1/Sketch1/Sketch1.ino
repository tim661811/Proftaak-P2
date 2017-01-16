unsigned long echo = 0;
int ultraSoundSignal = 9; // Ultrasound signal pin
unsigned long ultrasoundValue = 0;

#include "pitches.h"

String message = "";
char readChar;
int messageCount = 0;
bool messageStarted = false;
bool timerStarted;

// notes in the melody:
int melody[] = {
	NOTE_C4, NOTE_G3, NOTE_G3, NOTE_A3, NOTE_G3, 0, NOTE_B3, NOTE_C4
};

// note durations: 4 = quarter note, 8 = eighth note, etc.:
int noteDurations[] = {
	4, 8, 8, 4, 4, 4, 4, 4
};

void setup()
{
	Serial.begin(9600);
	pinMode(ultraSoundSignal, OUTPUT);
}


void loop()
{
	millis()
	int x = 0;
	x = ping();
	Serial.println(x);
	delay(250); //delay 1/4 seconds.

	if (x<20) {
		Serial.println("DISHES DETECTED!");
		timerStarted = true;
	}

	messaging();

}

///////////////////////////////////////functions///////////////////////////////////////////////////

unsigned long ping()
{
	pinMode(ultraSoundSignal, OUTPUT); // Switch signalpin to output
	digitalWrite(ultraSoundSignal, LOW); // Send low pulse 
	delayMicroseconds(2); // Wait for 2 microseconds
	digitalWrite(ultraSoundSignal, HIGH); // Send high pulse
	delayMicroseconds(5); // Wait for 5 microseconds
	digitalWrite(ultraSoundSignal, LOW); // Holdoff
	pinMode(ultraSoundSignal, INPUT); // Switch signalpin to input
	digitalWrite(ultraSoundSignal, HIGH); // Turn on pullup resistor
										  // please note that pulseIn has a 1sec timeout, which may
										  // not be desirable. Depending on your sensor specs, you
										  // can likely bound the time like this -- marcmerlin
										  // echo = pulseIn(ultraSoundSignal, HIGH, 38000)
	echo = pulseIn(ultraSoundSignal, HIGH); //Listen for echo
	ultrasoundValue = (echo / 58.138); //convert to CM then to inches
	return ultrasoundValue;
}


void playAlarm() {

	for (int thisNote = 0; thisNote < 8; thisNote++) {

		// to calculate the note duration, take one second
		// divided by the note type.
		//e.g. quarter note = 1000 / 4, eighth note = 1000/8, etc.
		int noteDuration = 1000 / noteDurations[thisNote];
		tone(8, melody[thisNote], noteDuration);

		// to distinguish the notes, set a minimum time between them.
		// the note's duration + 30% seems to work well:
		int pauseBetweenNotes = noteDuration * 1.30;
		delay(pauseBetweenNotes);
		// stop the tone playing:
		noTone(8);
	}
}

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

				Serial.print("The message I received was: ");
				Serial.println(message);
				checkIfMessageEquals();
				Serial.println("");
				Serial.println("");
			}

			if (readChar == '#')
			{
				messageStarted = true;
				Serial.println("messageStarted is true");
			}
		}
	}
}

// hier wordt gekeken of het ontvangen bericht gelijk is /n
// aan een vastgesteld bericht en vervolgens word er iets uitgevoerd
void checkIfMessageEquals() {

	if (message == "PLAY_ALARM")
	{
		playAlarm();
	}
	
}





