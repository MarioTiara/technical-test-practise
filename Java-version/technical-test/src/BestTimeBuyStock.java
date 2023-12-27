public class BestTimeBuyStock {
    public static int maxProfit(int[] prices){
        if (prices==null || prices.length<2){
            return  0;
        }

        int minPrice=prices[0];
        int maxProfit=0;

        for (int i=0; i<prices.length; i++){
            var potentialProfit= prices[i]-minPrice;
            maxProfit= Math.max(maxProfit, potentialProfit);
            minPrice=Math.min(minPrice, prices[i]);
        }

        return  maxProfit;
    }
}
