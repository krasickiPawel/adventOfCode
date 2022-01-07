// AdventOfCode2021.cpp : Ten plik zawiera funkcję „main”. W nim rozpoczyna się i kończy wykonywanie programu.
//

#include <iostream>
#include <fstream>
#include <string>
#include <ctime>

using namespace std;

int* fileRead() {
    static int fileData[2000];              //miejsce na 1000 komend i 1000 wartosci tych komend (tablica 1000 stringow zajmuje wiecej pamiec)
    ifstream file;
    string input;                           //zmienna pomocnicza przy odczycie pliku
    int inputOperation;

    file.open("input2.txt");

    for (int i = 0; i < 2000; i++) {
        
        file >> input;
        if (input == "forward") {           //sprawdzenie jaka to komenda i zamiana jej na odpowiednia wartosc
            inputOperation = -1;            //wartosci ujemne bo nie ma takich w danych advent of code
            fileData[i] = inputOperation;
        }
        else if (input == "down") {
            inputOperation = -2;
            fileData[i] = inputOperation;
        }
        else if (input == "up") {
            inputOperation = -3;
            fileData[i] = inputOperation;
        }
        else {
            fileData[i] = stoi(input);     //jesli to nie komenda to jest to wartosc liczbowa i zamieniamy ja na int i wpisujemy do tab
        }
    }

    file.close();

    return fileData;
}

int* task1(int* fileData) {
    int horisontalPosition = 0;
    int depth = 0;
    static int result[3];                   //wynik w postaci horisontal pos., depth i wymnozone

    for (int i = 0; i < 2000; i++) {        //wlasciwe obliczanie glebokosci i pozycji horyzontalnej
        if (fileData[i] == -1) {            //sprawdzenie jaka to komenda (forward, down, up) - tutaj forward
            horisontalPosition += fileData[i + 1];  //dodanie odpowiedniej wartosci do horisontal pos. 
            cout << "forward " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -2) {       //down
            depth += fileData[i + 1];
            cout << "down " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -3) {       //up
            depth -= fileData[i + 1];
            cout << "up " << fileData[i + 1] << endl;
        }
    }
    result[0] = horisontalPosition;
    result[1] = depth;
    result[2] = horisontalPosition * depth;

    return result;
}

int* task2(int* fileData) {
    int horisontalPosition = 0;
    int depth = 0;
    int aim = 0;                //roznica wzgledem task1 - patrz opis AoC 2021 day2 task2
    static int result[3];

    for (int i = 0; i < 2000; i++) {
        if (fileData[i] == -1) {
            horisontalPosition += fileData[i + 1];      //zwiekszanie hor. pos. o dana wartosc
            depth += aim*fileData[i + 1];               //i zwiekszanie depth o aim*dana wartosc
            cout << "forward " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -2) {
            aim += fileData[i + 1];                     //zwiekszanie aim gdy down
            cout << "down " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -3) {
            aim -= fileData[i + 1];                     //zmniejszanie aim gdy up
            cout << "up " << fileData[i + 1] << endl;
        }
    }
    result[0] = horisontalPosition;
    result[1] = depth;
    result[2] = horisontalPosition * depth;

    return result;
}

int main()
{
    clock_t start, elapsed;             //liczenie czasu wykonywania programu - dla mnie for fun
    start = clock();

    int* fileData = fileRead();         //odczyt pliku
    int* result = task1(fileData);      //wykonanie zad1

    cout << endl;
    cout << "Horisontal position " << result[0] << endl;
    cout << "Depth " << result[1] << endl;
    cout << "Result " << result[2] << endl;     //wypisanie wynikow zad1
    
    int* result2 = task2(fileData);     //wykonanie zad2

    cout << endl;
    cout << "Horisontal position " << result2[0] << endl;
    cout << "Depth " << result2[1] << endl;
    cout << "Result " << result2[2] << endl;    //wypisanie wynikow zad2

    elapsed = clock() - start;
    cout << "Time [ms] " << (1000*elapsed)/CLOCKS_PER_SEC << endl;  //wypisanie czasu

    return 0;
}

// Uruchomienie programu: Ctrl + F5 lub menu Debugowanie > Uruchom bez debugowania
// Debugowanie programu: F5 lub menu Debugowanie > Rozpocznij debugowanie

// Porady dotyczące rozpoczynania pracy:
//   1. Użyj okna Eksploratora rozwiązań, aby dodać pliki i zarządzać nimi
//   2. Użyj okna programu Team Explorer, aby nawiązać połączenie z kontrolą źródła
//   3. Użyj okna Dane wyjściowe, aby sprawdzić dane wyjściowe kompilacji i inne komunikaty
//   4. Użyj okna Lista błędów, aby zobaczyć błędy
//   5. Wybierz pozycję Projekt > Dodaj nowy element, aby utworzyć nowe pliki kodu, lub wybierz pozycję Projekt > Dodaj istniejący element, aby dodać istniejące pliku kodu do projektu
//   6. Aby w przyszłości ponownie otworzyć ten projekt, przejdź do pozycji Plik > Otwórz > Projekt i wybierz plik sln
