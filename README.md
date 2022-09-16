# Hackaton Assignment 1: Sportschool De Kast


Welcome to this repository.  


In this repository you will find the code for the first assignment of the school subject "Hackaton" with the case for a fake fitness center with the name "De Kast"  


## What is this assignment about?

Fitness center "De Kast" has a staff shortage. To make up for this shortage De Kast wants to change the occupation of the receptionists to trainers and want to replace there tasks with an no-receptionist solution  
It is up for this assignment to make this happen with an buget of 2000 (incl. programming (using an 40EUR/h rate))

## what are the requisites for running this program?

To run this project you need to have:
- An NFCReader (this program is created and tested with an "ACR122U" NFC Reader)
- An NFC Chip (It doesn't really matter what type of NFC Chip you use as long it does have an UID, to see all types of cards that worked see list under this requisite)
  - Student ID card (NXP MIFARE DESFire EV2 (MF3D82))
  - Dutch public transportation card (OV-Chipkaart)
  - NXP NTAG216 NFC card
- An laptop or desktop running Windows 7 or higher
- Visual Studio with WinForms tools downloaded (only to build or develop)

## How to build this project
1.  open the .sln file
2.  build for the first time the debug and release version (if you only want to use one of them you don't need the other) without using the app yet (see step 3 for why)
3.  after the first build is finished copy the /database/ folder to the same location as the executables (in: /fcsaas/bin/(release and/or debug)/net6.0-windows
4.  now you're set to use the software as intented
