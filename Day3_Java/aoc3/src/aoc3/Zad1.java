package aoc3;
import java.util.ArrayList;

public class Zad1 {
	
	
	private int gammaRate = 0;
	private int epsilonRate = 0;
		
	public void calculate(ArrayList<ArrayList<Integer>> fileList) {

		if(fileList.size() == 0 || fileList.get(0).size() == 0) return;
		
		String gamma = "";
		
		for(int i = 0; i < fileList.get(0).size(); i++) {
			int ones = 0;
			int zeros = 0;
			
			for(int j = 0; j < fileList.size(); j++) {
				if(fileList.get(j).get(i) == 1) ones++;
				else zeros++;
			}
			
			if(ones > zeros) gamma += "1";
			else gamma += "0";
		}
		
		String epsilon = "";
		
		for(char c: gamma.toCharArray()) {
			if(c == '0') epsilon += "1";
			else epsilon += "0";
		}
		
		System.out.println(gamma);
		System.out.println(epsilon);
		
		gammaRate = Integer.parseInt(gamma, 2);
		epsilonRate = Integer.parseInt(epsilon, 2);
		
		System.out.println(gammaRate);
		System.out.println(epsilonRate);
	}
	
	public int getResult() {
		return gammaRate * epsilonRate;
	}

}
