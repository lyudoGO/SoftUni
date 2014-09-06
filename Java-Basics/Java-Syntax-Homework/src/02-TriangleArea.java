import java.util.Scanner;


public class TriangleArea {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int pointAx = input.nextInt();
		int pointAy = input.nextInt();
		int pointBx = input.nextInt();
		int pointBy = input.nextInt();
		int pointCx = input.nextInt();
		int pointCy = input.nextInt();
		int area = Math.abs((pointAx*(pointBy-pointCy) + pointBx*(pointCy-pointAy) + pointCx*(pointAy-pointBy))/2);
		System.out.println(area);
	}
}
