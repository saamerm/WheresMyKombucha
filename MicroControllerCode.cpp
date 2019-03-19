int led1 = D7;
int led2 = D0;
int digitalValue;

void setup()
{

   pinMode(led1, OUTPUT);
   pinMode(led2, OUTPUT);

   Particle.function("led",ledToggle);
   Particle.variable("digitalValue", &digitalValue, INT);

   digitalWrite(led1, LOW);
   digitalWrite(led2, HIGH);

}

void loop()
{
   // Nothing to do here
}

int ledToggle(String command) {
    if (command=="on") {
        digitalWrite(led1,HIGH);
        digitalWrite(led2,LOW);
        digitalValue = 1;
        return 1;
    }
    else if (command=="off") {
        digitalWrite(led1,LOW);
        digitalWrite(led2,HIGH);
        digitalValue = 0;
        return 0;
    }
    else {
        digitalValue = -1;
        return -1;
    }
}
