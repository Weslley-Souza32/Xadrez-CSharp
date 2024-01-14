using tabuleiro;

namespace xadrez
{
    internal class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        /// <summary>
        /// Método para converter uma posição do xadrez para uma posição interna da matriz.
        /// </summary>
        /// <returns></returns>
        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            // a aspas força a conversão para string.
            return "" + coluna + linha;
        }
    }
}
