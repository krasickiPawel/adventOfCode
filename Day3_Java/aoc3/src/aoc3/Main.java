package aoc3;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		ArrayList<ArrayList<Integer>> data = fileRead();
		
		System.out.println("Zad1:");
		Zad1 zad1 = new Zad1();
		zad1.calculate(data);
		System.out.println("Result:");
		System.out.println(zad1.getResult());
		System.out.println();
		System.out.println("-----------------------------------------");
		
		System.out.println("Zad2:");
		Zad2 zad2 = new Zad2();
		zad2.calculate(data);
		System.out.println("Result:");
		System.out.println(zad2.getResult());
		System.out.println();
	}
	
	private static ArrayList<ArrayList<Integer>> fileRead(){
		ArrayList<ArrayList<Integer>> fileList = new ArrayList<>();
		try {
			File myFile = new File("C:\\Users\\Pawe³\\Documents\\studia\\3 rok\\AoC\\inputs\\input3.txt");
			Scanner myReader = new Scanner(myFile);
			while(myReader.hasNextLine()) {
				String data = myReader.nextLine();
				ArrayList<Integer> lineList = new ArrayList<>();
				for(char c : data.toCharArray()) {
					lineList.add(Character.getNumericValue(c));
				}
				fileList.add(lineList);
			}
			myReader.close();
		}
		catch(FileNotFoundException e) {
			System.out.println("Wyst¹pi³ b³¹d");
			e.printStackTrace();
		}
		return fileList;
	}

}
