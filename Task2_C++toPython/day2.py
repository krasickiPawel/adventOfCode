import time


INPUT_FILE = "input2.txt"


def fileRead():      # czytanie linijek i zapis oddzielonych wartosci do listy
    return [line.split() for line in open(INPUT_FILE, 'r')]


def task1(data):
    horizontalPosition = 0
    depth = 0

    for pair in data:
        if pair[0] == 'forward':
            horizontalPosition += int(pair[1])
            print(pair[0], pair[1])
        elif pair[0] == 'down':
            depth += int(pair[1])
            print(pair[0], pair[1])
        elif pair[0] == 'up':
            depth -= int(pair[1])
            print(pair[0], pair[1])

    resultList = [horizontalPosition, depth, horizontalPosition*depth]

    return resultList


def task2(data):
    horizontalPosition = 0
    depth = 0
    aim = 0

    for pair in data:
        if pair[0] == 'forward':
            horizontalPosition += int(pair[1])
            depth += aim*int(pair[1])
            print(pair[0], pair[1])
        elif pair[0] == 'down':
            aim += int(pair[1])
            print(pair[0], pair[1])
        elif pair[0] == 'up':
            aim -= int(pair[1])
            print(pair[0], pair[1])

    resultList = [horizontalPosition, depth, horizontalPosition * depth]

    return resultList


if __name__ == '__main__':
    start = time.time()
    fileData = fileRead()

    result = task1(fileData)
    print("Horisontal position ", result[0])
    print("Depth ", result[1])
    print("Result ", result[2])
    print()

    result2 = task2(fileData)
    print("Horisontal position ", result2[0])
    print("Depth ", result2[1])
    print("Result ", result2[2])

    print("Time [ms] ", 1000*(time.time()-start))
