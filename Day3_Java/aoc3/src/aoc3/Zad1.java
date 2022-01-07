package aoc3;
import java.util.ArrayList;

public class Zad1 {
	
	
	private int gammaRate = 0;		//rzeczy do obliczenia - skladowe powerConsumption, czyli gamma i epsilon
	private int epsilonRate = 0;	//kazdy bit w liczbie binarnej gamma rate to najpopularniejszy bit danej kolumny w danych, epsilon to odwrotnosc gamma binarnie
		
	public void calculate(ArrayList<ArrayList<Integer>> fileList) {		//przyjmuje plik z danymi

		if(fileList.size() == 0 || fileList.get(0).size() == 0) return; //zabezpieczenie gdy plik jest pusty
		
		String gamma = "";
		
		for(int i = 0; i < fileList.get(0).size(); i++) {				//dla kazdej pozycji ("kolumny") w ciagu binarnym
			int ones = 0;
			int zeros = 0;
			
			for(int j = 0; j < fileList.size(); j++) {					//dla kazdego wiersza (ciagu binarnego)
				if(fileList.get(j).get(i) == 1) ones++;					//jesli wartosc to 1 to zwieszamy ilosc jedynek o 1
				else zeros++;											//else zwiekszamy ilosc 0 o 1
			}
			
			if(ones > zeros) gamma += "1";								//sprawdzamy czy jest wiecej 1 czy 0 w danej kolumnie
			else gamma += "0";											//i zapisujemy odpowiednia wartosc na tej pozycji (kolumnie) wyniku gamma
		}
		
		String epsilon = "";
		
		for(char c: gamma.toCharArray()) {								//zamiana string na chary i odwrocenie wszystkich wartosci binarnych
			if(c == '0') epsilon += "1";
			else epsilon += "0";
		}
		
		System.out.println(gamma);
		System.out.println(epsilon);
		
		gammaRate = Integer.parseInt(gamma, 2);							//zamiana gamma na dziesietne i epsilon tez
		epsilonRate = Integer.parseInt(epsilon, 2);						//ogolnie zamiana stringa na int - podany drugi argument "2" sugeruje, ze jest to binarne
		
		System.out.println(gammaRate);
		System.out.println(epsilonRate);
	}
	
	public int getResult() {
		return gammaRate * epsilonRate;		// wynik power consumption podany dziesietnie
	}

}
