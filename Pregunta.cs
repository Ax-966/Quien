using System.Dynamic;

namespace TP
{
    public class Pregunta
    {
        private string pregunta;
        public Pregunta(string pregunta)
        {
            this.pregunta = pregunta;
        }
        public string Pre
        {
            get
            {
                return pregunta;
            }
            set
            {
                pregunta = value;
            }
        }
    }
}