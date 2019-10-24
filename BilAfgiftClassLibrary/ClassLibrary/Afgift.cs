using System;

namespace ClassLibrary
{
    public class Afgift
    {
        //metode til at beregne bilafgiften på normale biler.
        public static int BilAfgift(int pris)
        {
            //Hvis prisen er større end nul, foretages der beregning.
            if (pris > 0)
            {
                //Hvis prisen er under 200000 udregnes udgiften som 85% af bilens pris.
                if (pris <= 200000)
                {
                    return Convert.ToInt32(pris * 0.85);
                }

                //Er prisen større end 200000 udregnes udgiften som 150% af prisen minus 130000.
                else return Convert.ToInt32(pris * 1.5 - 130000);
            }

            //Er prisen nul eller negativ smides der en exeption.
            else throw new ArgumentOutOfRangeException();
        }

        //metode til at beregne afgift på elbiler.
        public static int ElbilAfgift(int pris)
        {
            //Da afgiften på elbiler altid er 20% af den normale udgift, kaldes metoden til at udregne den normale afgift og returnerer så 20% af dette resultat.
            return Convert.ToInt32(BilAfgift(pris) * 0.20);
        }
    }
}
