namespace work
{
    class Polinom // 2.A
    {
        private int factor;
        private int power;
        public Polinom(int factor, int power)
        {
            this.factor = factor;
            this.power = power;
        }

        public int GetFactor()
        {
            return this.factor;
        }
        public int GetPower()
        {
            return this.power;
        }
        public void SetFactor(int factor)
        {
            this.factor = factor;
        }
        public void SetPower(int power)
        {
            this.power = power;
        }

        public override string ToString()
        {
            return this.factor + "x^" + this.power;
        }
    }
}