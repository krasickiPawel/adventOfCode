import time

# import numpy as np


def zlyFileRead():
    data = []
    with open("input5.txt") as file:
        while (line := file.readline()) != "":  # czytanie linijek do konca pliku
            data.append(line[:-1])              # zamiana wartosci na int i dodanie do listy przechowujace dane z pliku
    return data


def fileRead():
    with open('input5.txt') as f:
        data = f.readlines()
    return data


def prepareData(fileData):
    return [[int(point[0].split(",")[0]), int(point[0].split(",")[1]), int(point[1].split(",")[0]), int(point[1].split(",")[1])] for point in [line.split(" -> ") for line in fileData]]


def task1(dataListUnfiltered):
    dataList = [tab for tab in dataListUnfiltered if tab[0] == tab[2] or tab[1] == tab[3]]

    maxSize = max(dataList[0])
    for tab in dataList:
        localMax = max(tab)
        if localMax > maxSize:
            maxSize = localMax

    # existingPoints = []
    diagram = [[0] * (maxSize + 1) for _ in range(maxSize + 1)]

    for lineEndPoints in dataList:
        if lineEndPoints[0] == lineEndPoints[2]:
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

            firstIndex = min(lineEndPoints[1], lineEndPoints[3])
            secondIndex = max(lineEndPoints[1], lineEndPoints[3])
            for i in range(firstIndex, secondIndex + 1):
                diagram[lineEndPoints[0]][i] += 1

        elif lineEndPoints[1] == lineEndPoints[3]:
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

    res = len([val for row in diagram for val in row if val >= 2])
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


def task2(unfilteredData):
    maxSize = max(unfilteredData[0])
    for tab in unfilteredData:
        localMax = max(tab)
        if localMax > maxSize:
            maxSize = localMax

    diagram = [[0] * (maxSize + 1) for _ in range(maxSize + 1)]

    for row in unfilteredData:
        if row[0] == row[2]:
            firstIndex = min(row[1], row[3])
            secondIndex = max(row[1], row[3])
            for i in range(firstIndex, secondIndex + 1):
                diagram[row[0]][i] += 1

        elif row[1] == row[3]:
            firstIndex = min(row[0], row[2])
            secondIndex = max(row[0], row[2])
            for i in range(firstIndex, secondIndex + 1):
                diagram[i][row[1]] += 1
        else:
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
            xInc = 1 if row[0] < row[2] else -1
            yInc = 1 if row[1] < row[3] else -1
            rangeX = [i for i in range(row[0], row[2], xInc)]
            rangeX.append(row[2])
            rangeY = [i for i in range(row[1], row[3], yInc)]
            rangeY.append(row[3])

            for i in range(len(rangeX)):
                diagram[rangeX[i]][rangeY[i]] += 1

    return len([val for row in diagram for val in row if val >= 2])


if __name__ == '__main__':
    preparedData = prepareData(fileRead())              # lista z danymi

    start = time.time()
    result = task1(preparedData)
    stop = time.time()
    print(result, stop-start)

    print()

    start = time.time()
    result2 = task2(preparedData)
    stop = time.time()
    print(result2, stop-start)
