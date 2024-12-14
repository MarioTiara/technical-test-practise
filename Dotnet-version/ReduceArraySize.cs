

namespace Technical_Test_Practice
{
    public class ReduceArraySize
    {
        public static int Result(List<int> list)
        {

            var halfListLenght = list.Count / 2;

            //hitung jumlah kemunculan bilangan di array
            var count= new  Dictionary<int, int>();
            foreach (var item in list){
                if (!count.ContainsKey(item))
                    count.Add(item,0);
                count[item]++;
            }
  
            var result=0;

            //selama panjang array lebih dari setengah panjang awal array tersebut (karena elemen array akan perlahan di hapus)
            while (list.Count > halfListLenght)
            {

                //ambil element dengan jumlah kemunculan tertinggi
                var m=0;
                var l=0;
                foreach (var (k, v) in count){
                    if (m<v){
                        m=v;
                        l=k;
                    }
                }
                //set elemen dengan kemunculan tertinggi menjadi 0
                //agar tidak dihitung lagi di next loop
                count[l]=0;

                // hapus elemen yang jumlah kemunculannya tertinggi
                list= list.Where(x=>x!=l).ToList();
                result++;
            }

            return result;



        }
    }
}