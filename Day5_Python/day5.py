import time

# import numpy as np                            # udalo sie to zrobic tak samo wydajnie bez numpy - wniosek: matematyka to najlepsza optymalizacja kodu :)
                                                # ale numpy i tak zaskakuje swoja predkoscia (zly kod bez numpy - liczenie 15 min, zly kod z numpy - liczenie wyniku ponizej dwoch sekund)

def zlyFileRead():                              # przestroga na przyszlosc
    data = []
    with open("input5.txt") as file:
        while (line := file.readline()) != "":  # czytanie linijek do konca pliku
            data.append(line[:-1])              # zamiana wartosci na int i dodanie do listy przechowujace dane z pliku
    return data


def fileRead():                                 # tak sie robi fileRead zeby nie wpasc w pulapke (w sumie po dlugim debugowaniu nie wiem czemu powyzsze powoduje bledy)
    with open('input5.txt') as f:
        data = f.readlines()
    return data                                 # linijki w formacie x1,y1 -> x2,y2


def prepareData(fileData):                      # okrojenie surowych linijek z pliku tak, zeby kazda linijka byla reprezentowana przez tablice 4 wartosci
    return [[int(point[0].split(",")[0]), int(point[0].split(",")[1]), int(point[1].split(",")[0]), int(point[1].split(",")[1])] for point in [line.split(" -> ") for line in fileData]]


def task1(dataListUnfiltered):
    dataList = [tab for tab in dataListUnfiltered if tab[0] == tab[2] or tab[1] == tab[3]]
    # BIERZEMY POD UWAGĘ LINIE w których x1 = x2 albo y1 = y2 (czyli tylko pionowe lub poziome)
    maxSize = max(dataList[0])
    for tab in dataList:
        localMax = max(tab)
        if localMax > maxSize:  # ograniczenie diagramu wynikowego do maksymalnie istniejacej wartosci w danych od AoC
            maxSize = localMax

    # existingPoints = []                                           # tworzymy diagram czyli liste NxN wypelniona zerami zeby dodawac pozniej do danej pozycji
    diagram = [[0] * (maxSize + 1) for _ in range(maxSize + 1)]     # +1 bo range nie uwzglednia ostatniej liczby z przedzialu, a maxSize jest indeksem ktory bedziemy uzywac

    for lineEndPoints in dataList:                                  # dla kazdego zestawu liczb (listy 4 wartosci bedacych odpowiednimi punktami linii gejzera)
        if lineEndPoints[0] == lineEndPoints[2]:                    # rozpatrujemy tu linie pionowe
            # if lineEndPoints[1] >= lineEndPoints[3]:
            #     firstIndex = lineEndPoints[3]
            #     secondIndex = lineEndPoints[1]
            # else:
            #     firstIndex = lineEndPoints[1]
            #     secondIndex = lineEndPoints[3]
            #
            # for i in range(firstIndex, secondIndex + 1):
            #     # existingPoints.append(f"{lineEndPoints[0], i}")
            #     diagram[lineEndPoints[0]][i] += 1

            firstIndex = min(lineEndPoints[1], lineEndPoints[3])    # wybieramy pierwszy (mniejsz) index do fora
            secondIndex = max(lineEndPoints[1], lineEndPoints[3])
            for i in range(firstIndex, secondIndex + 1):            # dla kazdych punktow koncowych i poczatkowych wyznaczamy punkty pomiedzy
                diagram[lineEndPoints[0]][i] += 1                   # i wpisujemy na diagrami w ktorej sa pozycji +1 bo tam wystepuje akurat ta jedna linia (jesli w danym punkcie bedzie sie nawartwiac druga linia to +1 pomoze nam to zidentyfikowac)

        elif lineEndPoints[1] == lineEndPoints[3]:                  # to samo dla linii poziomych
            # if lineEndPoints[0] >= lineEndPoints[2]:
            #     firstIndex = lineEndPoints[2]
            #     secondIndex = lineEndPoints[0]
            # else:
            #     firstIndex = lineEndPoints[0]
            #     secondIndex = lineEndPoints[2]
            #
            # for i in range(firstIndex, secondIndex + 1):
            #     # existingPoints.append(f"{i, lineEndPoints[1]}")
            #     diagram[i][lineEndPoints[1]] += 1

            firstIndex = min(lineEndPoints[0], lineEndPoints[2])
            secondIndex = max(lineEndPoints[0], lineEndPoints[2])
            for i in range(firstIndex, secondIndex + 1):
                diagram[i][lineEndPoints[1]] += 1

    res = len([val for row in diagram for val in row if val >= 2])      # sprawdzamy kazda pozycje (kolumna, wiersz) w diagramie czy wartosc >= 2 i tworzymy liste tylko takich wartosci, a nastepnie liczymy dlugosc tej listy (zeby sie dowiedziec ile jest wystapien tych wartosci)
    # counted = dict(zip(*np.unique(existingPoints, return_counts=True)))
    # print(counted)
    # res = len([val for val in counted.values() if val >= 2])

    # for i in range(maxSize + 1):
    #     for j in range(maxSize + 1):
    #         diagram[i][j] = existingPoints.count([i, j])
    #         print(diagram[i][j], i, j)
    #         if diagram[i][j] >= 2:
    #             counter += 1

    return res


def task2(unfilteredData):                                          # rozszerzona wersja task1 dla czytelnosci (task1 je zrobione tu duzo krocej)
    maxSize = max(unfilteredData[0])                                # liczenie linii skosnych jest tu mozliwe i dosc proste ze wzgledu takiego, ze jest pewna zasada
    for tab in unfilteredData:                                      # zeby dojsc z a,b -> c,d to w kazdym ruchu mozemy +1 lub -1 na a, b i nie zmieniac znaku w trakcie
        localMax = max(tab)                                         # innymi slowy abs(a-c) == abs(b-d)
        if localMax > maxSize:
            maxSize = localMax

    diagram = [[0] * (maxSize + 1) for _ in range(maxSize + 1)]

    for row in unfilteredData:
        if row[0] == row[2]:                                        # linie pionowe gdy x takie same
            firstIndex = min(row[1], row[3])
            secondIndex = max(row[1], row[3])
            for i in range(firstIndex, secondIndex + 1):
                diagram[row[0]][i] += 1

        elif row[1] == row[3]:                                      # linie poziome gdu y takie same
            firstIndex = min(row[0], row[2])
            secondIndex = max(row[0], row[2])
            for i in range(firstIndex, secondIndex + 1):
                diagram[i][row[1]] += 1
        else:                                                       # linie skosne
            # if row[0] < row[2]:
            #     rangeX = [i for i in range(row[0], row[2])]
            #     rangeX.append(row[2])
            # else:
            #     rangeX = [i for i in range(row[0], row[2], -1)]
            #     rangeX.append(row[2])
            # if row[1] < row[3]:
            #     rangeY = [i for i in range(row[1], row[3])]
            #     rangeY.append(row[3])
            # else:
            #     rangeY = [i for i in range(row[1], row[3], -1)]
            #     rangeY.append(row[3])
            xInc = 1 if row[0] < row[2] else -1                     # sposob inkrementacji w forze (++ czy --)
            yInc = 1 if row[1] < row[3] else -1                     # na podstawie ktory koniec ma wieksza wartosc
            rangeX = [i for i in range(row[0], row[2], xInc)]       # skorzystanie z zasady opisanej od linijki 86
            rangeX.append(row[2])                                   # dodanie wartosci x punktu na drugim koncu bo range nie uwzglednia konca przedzialu
            rangeY = [i for i in range(row[1], row[3], yInc)]       # wypisanie punktow co 1 od pierwszego do drugiego lacznie z drugim
            rangeY.append(row[3])

            for i in range(len(rangeX)):                            # dla wszystkich pkt od pierwszego do koncowego linii gejzera dodajemy 1 w diagramie na odpowiedniej pozycji
                diagram[rangeX[i]][rangeY[i]] += 1                  # PAMIETAJMY jest to ten sam diagram co w liniach poziomych i pionowych wiec sumujemy wszystkie mozliwe linie i wyjdzie inny wynik

    return len([val for row in diagram for val in row if val >= 2]) # obliczenie ilosci punktow w diagramie gdzie wartosci >=2


if __name__ == '__main__':
    preparedData = prepareData(fileRead())              # lista z danymi po obrobieniu listy z fileRead

    start = time.time()
    result = task1(preparedData)                        # obliczenie task1
    stop = time.time()                                  # testy wydajnosci dla mnie for fun
    print(result, stop-start)                           # wypisanie wyniku task1

    print()

    start = time.time()
    result2 = task2(preparedData)                       # obliczenie task2
    stop = time.time()
    print(result2, stop-start)                          # wypisanie wyniku task2
