package aoc3;

import java.util.ArrayList;

public class Zad2 {

	private int oxygenGeneratorRating = 0;
	private int co2ScrubberRating = 0;
	
	public void calculate(ArrayList<ArrayList<Integer>> fileList) {
		if(fileList.size() == 0 || fileList.get(0).size() == 0) return;
		
		calculateOxygen((ArrayList<ArrayList<Integer>>)fileList.clone());
		calculateCO2((ArrayList<ArrayList<Integer>>)fileList.clone());

	}
	
	private void calculateOxygen(ArrayList<ArrayList<Integer>> resultList) {
		String oxygenRating = "";
		
		recurrentMethod(resultList, 0, resultList.get(0).size() - 1, "oxygen");
		System.out.println(resultList.size());
		
		if(resultList.size() == 1) {
			for(int number : resultList.get(0)) {
				oxygenRating += String.valueOf(number);
			}
			System.out.println(oxygenRating);
			oxygenGeneratorRating = Integer.parseInt(oxygenRating, 2);
			System.out.println(oxygenGeneratorRating);
		}
	}
	
	private void calculateCO2(ArrayList<ArrayList<Integer>> resultList) {
		String co2Rating = "";
		
		recurrentMethod(resultList, 0, resultList.get(0).size() - 1, "co2");
		
		System.out.println(resultList.size());
		
		if(resultList.size() == 1) {
			for(int number : resultList.get(0)) {
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
		ArrayList<ArrayList<Integer>> tempList = new ArrayList<>();
		
		
		for(int i = 0; i < resultList.size(); i++) {
			if(resultList.get(i).get(currentIndex) == 1) ones++;
			else zeros++;
		}
		
		if(type == "oxygen") {
			if(ones >= zeros) {
				for(int i = 0; i < resultList.size(); i++) {
					if(resultList.get(i).get(currentIndex) == 1) tempList.add(resultList.get(i));
				}
			}
			else {
				for(int i = 0; i < resultList.size(); i++) {
					if(resultList.get(i).get(currentIndex) == 0) tempList.add(resultList.get(i));
				}
			}
		}
		else if(type == "co2") {
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

		
		resultList.clear();
		for(ArrayList<Integer> sequence : tempList) {
			resultList.add(sequence);
		}
		
		if(currentIndex < maxIndex && resultList.size() > 1) {
			recurrentMethod(resultList, currentIndex + 1, maxIndex, type);	
		}
		
	}
	
	public int getResult() {
		return oxygenGeneratorRating * co2ScrubberRating;
	}
}
