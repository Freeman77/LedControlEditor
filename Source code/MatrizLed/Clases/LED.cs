
namespace MatrizLed
{
    public class LED
    {
        public string ID { get; set; }
        public string Color { get; set; }
        public bool Encendido { get; set; }
        public int ValorNumericoHorizontal { get; set; }
        public int ValorNumericoVertical { get; set; }

        public LED() {
        }

        public void cambiarEstado(){
            this.Encendido = !this.Encendido;
        }
    }
}
