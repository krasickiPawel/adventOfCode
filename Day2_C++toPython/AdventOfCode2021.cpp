// AdventOfCode2021.cpp : Ten plik zawiera funkcję „main”. W nim rozpoczyna się i kończy wykonywanie programu.
//

#include <iostream>
#include <fstream>
#include <string>
#include <ctime>

using namespace std;

int* fileRead() {
    static int fileData[2000];
    ifstream file;
    string input;
    int inputOperation;

    file.open("input2.txt");

    for (int i = 0; i < 2000; i++) {
        
        file >> input;
        if (input == "forward") {
            inputOperation = -1;
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
            fileData[i] = stoi(input);
        }
    }

    file.close();

    return fileData;
}

int* task1(int* fileData) {
    int horisontalPosition = 0;
    int depth = 0;
    static int result[3];

    for (int i = 0; i < 2000; i++) {
        if (fileData[i] == -1) {
            horisontalPosition += fileData[i + 1];
            cout << "forward " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -2) {
            depth += fileData[i + 1];
            cout << "down " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -3) {
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
    int aim = 0;
    static int result[3];

    for (int i = 0; i < 2000; i++) {
        if (fileData[i] == -1) {
            horisontalPosition += fileData[i + 1];
            depth += aim*fileData[i + 1];
            cout << "forward " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -2) {
            aim += fileData[i + 1];
            cout << "down " << fileData[i + 1] << endl;
        }
        else if (fileData[i] == -3) {
            aim -= fileData[i + 1];
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
    clock_t start, elapsed;
    start = clock();

    int* fileData = fileRead();
    int* result = task1(fileData);

    cout << endl;
    cout << "Horisontal position " << result[0] << endl;
    cout << "Depth " << result[1] << endl;
    cout << "Result " << result[2] << endl;
    
    int* result2 = task2(fileData);

    cout << endl;
    cout << "Horisontal position " << result2[0] << endl;
    cout << "Depth " << result2[1] << endl;
    cout << "Result " << result2[2] << endl;

    elapsed = clock() - start;
    cout << "Time [ms] " << (1000*elapsed)/CLOCKS_PER_SEC << endl;

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
