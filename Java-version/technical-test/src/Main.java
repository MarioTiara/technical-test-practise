import java.util.ArrayList;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
       var input= "1615UGHCVTBQZSALWQODAQSSXWQHCKWOVMVAHIOCMLAQMZIONLMVRAQWROTHFMBTXSVQKRFBKDFGCBEMBJDLRQETKGOHLQVLBRGWSGLBLDAQWQOELDPLIKDNVKVDVHSKFORLOGLLBJDHFIEKODLHPDMWEKLFWNAJEDPOAYTDDKDGPESNFYFLMAKEFKFOGEWRKGLHADKFMXDPWLQPFJGLJGGLDPRLWQLMNVJFKTKPLSGLDOSMGOHM";

        List<String> huruf = new ArrayList<>();
        huruf.add("UGHCVTBQZSALWQO");
        huruf.add("DAQSSXWQHCKWOVM");

        huruf.add("VAHIOCMLAQMZION");

        huruf.add("LMVRAQWROTHFMBT");

        huruf.add("XSVQKRFBKDFGCBE");

        huruf.add("MBJDLRQETKGOHLQ");

        huruf.add("VLBRGWSGLBLDAQW");

        huruf.add("QOELDPLIKDNVKVD");

        huruf.add("VHSKFORLOGLLBJD");

        huruf.add("HFIEKODLHPDMWEK");

        huruf.add("LFWNAJEDPOAYTDD");

        huruf.add("KDGPESNFYFLMAKE");

        huruf.add("FKFOGEWRKGLHADK");

        huruf.add("FMXDPWLQPFJGLJG");

        huruf.add("GLDPRLWQLMNVJFK");
        huruf.add("TKPLSGLDOSMGOHM");
        //var result= HuruAcak.cari(huruf, new ArrayList<>());

      // var result= HuruAcak.isContains("LFWNAJEDPOAYTDD", "ADA");

       //System.out.println(result);
       List<String> kata= new ArrayList<>();
       kata.add("ADA");
       kata.add("TOKO");
       kata.add("SIAPA");

       var test= HuruAcak.cari(huruf, kata);

        int[][] twoDArray = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
        };

        // Traverse the array diagonally
        diagonalTraversal(twoDArray);
    }

    private static void diagonalTraversal(int[][] array) {
        int rows = array.length;
        int columns = array[0].length;

        System.out.println("Diagonal Traversal:");

        // Traverse the main diagonal (top-left to bottom-right)
        for (int i = 0; i < Math.min(rows, columns); i++) {
            System.out.print(array[i][i] + " ");
        }
        System.out.println(); // Move to the next line

        // Traverse the secondary diagonal (top-right to bottom-left)
        for (int i = 0; i < Math.min(rows, columns); i++) {
            System.out.print(array[i][columns - i - 1] + " ");
        }
        System.out.println(); // Move to the next line
    }

}