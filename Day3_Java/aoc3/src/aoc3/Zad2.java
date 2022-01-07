package aoc3;

import java.util.ArrayList;

public class Zad2 {

	private int oxygenGeneratorRating = 0;
	private int co2ScrubberRating = 0;
	
	public void calculate(ArrayList<ArrayList<Integer>> fileList) {
		if(fileList.size() == 0 || fileList.get(0).size() == 0) return;			//przerwanie gdy zly plik lub brak
		//uzywamy klonu pliku bo bedziemy na nim operowac i edytowac - chodzi o to, zeby obliczanie co2 bazowalo na pierwoynych danych
		calculateOxygen((ArrayList<ArrayList<Integer>>)fileList.clone());		//warning bo java nie ufa ze dobrze rzutujemy
		calculateCO2((ArrayList<ArrayList<Integer>>)fileList.clone());			//obliczanie wartosci oxygen i co2

	}
	
	private void calculateOxygen(ArrayList<ArrayList<Integer>> resultList) {
		String oxygenRating = "";												//string bo inaczej nie zapiszemy liczb binarnych
		
		recurrentMethod(resultList, 0, resultList.get(0).size() - 1, "oxygen");	//rekurencyjne obliczenie wartosci tlenu
		System.out.println(resultList.size());									//kontrola dla mnie czy dziala poprawnie
		
		if(resultList.size() == 1) {											//jesli wylonilismy ta odpowiednia liczbe binarna z bit criteria (patrz AoC 2021 day3 task2
			for(int number : resultList.get(0)) {								//bit criteria - najczestszy bit na obecnej pozycji
				oxygenRating += String.valueOf(number);							//jesli 0 i 1 tak samo czesto to bierzemy 1
			}																	//nastepuje tu zapisanie znalezionej liczby
			System.out.println(oxygenRating);
			oxygenGeneratorRating = Integer.parseInt(oxygenRating, 2);			//zamiana binarnej w stringu na int dziesietne
			System.out.println(oxygenGeneratorRating);
		}
	}
	
	private void calculateCO2(ArrayList<ArrayList<Integer>> resultList) {
		String co2Rating = "";													//szukamy najrzadszego bitu na danej pozycji, jesli po rowno to bierzemy 0
		
		recurrentMethod(resultList, 0, resultList.get(0).size() - 1, "co2");	//pierwsze wywolanie ("rozpoczecie") rekurencji
		
		System.out.println(resultList.size());
		
		if(resultList.size() == 1) {
			for(int number : resultList.get(0)) {								//to samo co dla oxygen
				co2Rating += String.valueOf(number);
			}
			System.out.println(co2Rating);
			co2ScrubberRating = Integer.parseInt(co2Rating, 2);
			System.out.println(co2ScrubberRating);
		}
		
	}
	
	private void recurrentMethod(ArrayList<ArrayList<Integer>> resultList, int currentIndex, int maxIndex, String type) {
		int ones = 0;
		int zeros = 0;
		ArrayList<ArrayList<Integer>> tempList = new ArrayList<>();	//lista sluzaca do pomocy w odfiltrowywaniu wynikow
		//fajna rekurencja
		
		for(int i = 0; i < resultList.size(); i++) {				//dla kazdego wiersza w pliku z danymi (wiadomo ze robimy to z uzyciem listy, ale potocznie dla zrozumienia opis pliku)
			if(resultList.get(i).get(currentIndex) == 1) ones++;	//sprawdzenie czy na obecnej pozycji kolumny w liczbie binarnej jest 1 czy 0 (pozycja podana do funkcji rekurencyjnej zmienia sie z kazdym wywolaniem)
			else zeros++;											//no i takie sprawdzenie dla wszystkich wierszy
		}
		
		if(type == "oxygen") {										//oszczednosc kodu - rekurencja dziala dla oxygen i co2 tylko tutaj rozrozniamy na czym operujemy
			if(ones >= zeros) {										//jesli jedynek jest wiecej lub tyle samo
				for(int i = 0; i < resultList.size(); i++) {		//to wybieramy tylko te liczby, ktore maja na tej danej pozycji jedynki i je zapisujemy w liscie pomocniczej
					if(resultList.get(i).get(currentIndex) == 1) tempList.add(resultList.get(i));
				}
			}
			else {
				for(int i = 0; i < resultList.size(); i++) {		//tutaj operacja dokladnie przeciwna
					if(resultList.get(i).get(currentIndex) == 0) tempList.add(resultList.get(i));
				}
			}
		}
		else if(type == "co2") {									//w co2 jesli zer jest mniej lub tyle samo to bierzemy pod uwage tylko liczby z zerami na danej pozycji
			if(zeros <= ones) {
				for(int i = 0; i < resultList.size(); i++) {
					if(resultList.get(i).get(currentIndex) == 0) tempList.add(resultList.get(i));
				}
			}
			else {
				for(int i = 0; i < resultList.size(); i++) {
					if(resultList.get(i).get(currentIndex) == 1) tempList.add(resultList.get(i));
				}
			}
		}

		
		resultList.clear();											//czyscimy liste z danymi z pliku (z poprzedniej rekurencji) i wpisujemy aktualne wybrane liczby
		for(ArrayList<Integer> sequence : tempList) {
			resultList.add(sequence);
		}
		
		if(currentIndex < maxIndex && resultList.size() > 1) {		//powtarzamy rekurencje do momentu az bedziemy na ostatniej pozycji w liczbie (ostatniej kolumnie) i jesli ta jedna jedyna liczba nie zostala jeszcze znaleziona
			recurrentMethod(resultList, currentIndex + 1, maxIndex, type);	
		}
		
	}
	
	public int getResult() {
		return oxygenGeneratorRating * co2ScrubberRating;			//zwracamy wynik dziesietny
	}
}
