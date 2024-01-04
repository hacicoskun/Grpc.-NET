namespace RestApi
{

    public abstract record MyTestBaseDto
    {
        protected internal int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
        private int MyProperty4 { get; set; }  
        public virtual bool MyMethod() { return true; }
    }

    public record MyTest2 : MyTestBaseDto
    { 
        public override bool MyMethod()
        {
            return base.MyMethod();
        } 
    }
}
