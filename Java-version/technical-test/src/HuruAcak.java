import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class HuruAcak {
    public static List<String> cari(List<String> huruf, List<String> kata){

        List<String>  result= new ArrayList<>();
        Map<String, String> rsMap= new HashMap<>();
        for (String k:kata){
            //horizontal check
            if (!rsMap.containsKey(k)){
                for (String h:huruf){
                    if (isContains(h, k)){
                        rsMap.put(k, "YA");
                        break;
                    }else {
                        rsMap.put(k, "TIDAK");
                    }
                }
            }


            //cek vertikal
            if (!rsMap.containsKey(k)){
                var column=huruf.get(0).length();
                var row= huruf.size();
                List<String> verticalHuruf= new ArrayList<>();
                for (int j=0; j<column; j++){
                    char [] newHuruf= new char[row];
                    for (int i=0; i<row; i++){
                        newHuruf[i]=huruf.get(i).charAt(j);
                    }
                    verticalHuruf.add(new String(newHuruf));
                    System.out.println(verticalHuruf.getClass());
                }
                for (String h:verticalHuruf){
                    if (isContains(h, k)){
                        rsMap.put(k, "YA");
                        break;
                    }else {
                        rsMap.put(k, "TIDAK");
                    }
                }
            }


            //Cek diagonal
            if (!rsMap.containsKey(k)){
                var column=huruf.get(0).length();
                var row= huruf.size();
                List<String> diagonallHuruf= new ArrayList<>();
                char[] newHuruf= new char[Math.min(column, row)];
                for (int i=0; i<Math.min(column, row); i++){
                    newHuruf[i]=huruf.get(i).charAt(i);
                }
                diagonallHuruf.add(new String(newHuruf));

                newHuruf= new char[Math.min(column, row)];
                for (int i = 0; i < Math.min(row, column); i++) {
                    var hr=huruf.get(i);
                    var ch= hr.charAt(column-1-i);
                    newHuruf[i]=ch;
                }

                diagonallHuruf.add(new String(newHuruf));
                for (String h:diagonallHuruf){
                    if (isContains(h, k)){
                        rsMap.put(k, "YA");
                        break;
                    }else {
                        rsMap.put(k, "TIDAK");
                    }
                }
            }

        }

        for (var entry : rsMap.entrySet()) {
            result.add(entry.getValue());
        }

        return  result;

    }

    public static    boolean isContains(String huruf, String kata){
        int hPointer=0;
        int kPointer=0;
        boolean isCointain=false;
        while (hPointer<huruf.length() && kPointer<kata.length()){
            if (huruf.charAt(hPointer)==kata.charAt(kPointer) && kPointer!=kata.length()-1) kPointer++;
            if (huruf.charAt(hPointer)==kata.charAt(kPointer) && kPointer==kata.length()-1){
                isCointain= true;
                break;
            }
            hPointer++;
        }
        return  isCointain;
    }


}
