
## Free serial port while flashing


When this option is checked, the program constantly monitors the inserted path for new or modified binary files to determine if another program will attempt to flash the connected a microcontroller.


<img width="795" height="448" alt="image" src="https://github.com/user-attachments/assets/4a626243-4c4c-4956-a0af-d0b700f33c9a" />


##### Output Path
The location where binaries are before flashing.

##### File type
The file extension used. Esps use .bin, Arduino Uno uses .hex, .elf

##### Close port at File:
After how many files the program assumes an incoming flashing attempt?
When this threshold is met the port is disconnected.


##### Assume flashing at - After
After how many files the program starts checking for flashing attempt.
If the X program outputs 4 binaries and then flashes, set this to 4.
The program detects flashing when an attempted connection fails so **"After"** MUST guarantee that flashing is taking place. 


##### Presets:
The default settings are for a generic Esp 32 board flashed with Arduino IDE.





