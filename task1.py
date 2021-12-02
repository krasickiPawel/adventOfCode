def fileRead():
    data = []
    with open("input1.txt") as file:
        while (line := file.readline()) != "":  # czytanie linijek do konca pliku
            data.append(int(line[:-1]))         # zamiana wartosci na int i dodanie do listy przechowujace dane z pliku
    return data


def checkIncreased(data):
    lastMeasurement = data[0]                   # zeby cos bylo na start
    increased = 0                               # licznik
    for measurement in data:
        if measurement > lastMeasurement:       # sprawdzenie czy pomiar jest wiekszy (czy jest glebiej)
            increased += 1                      # zwiekszenie licznika jesli pomiar jest wiekszy
        lastMeasurement = measurement           # zapamietanie ostatnio badanego pomiaru
    return increased


def checkIncreased_2(data):
    increasedSum = 0
    for i in range(len(data)-3):                # rozmiar-3 zeby utworzyc ostatnia trojke do porownania
        if data[i]+data[i+1]+data[i+2] < data[i+1]+data[i+2]+data[i+3]:
            increasedSum += 1                   # jesli nastepna trojka wieksza to zwiekszamy licznik
    return increasedSum


if __name__ == '__main__':
    fileData = fileRead()                       # lista z danymi
    result = checkIncreased(fileData)           # ilosc wystapien "increased" dla pojedynczych pomiarow
    print(result)
    result_2 = checkIncreased_2(fileData)       # ilosc wiekszych sum trojek
    print(result_2)
