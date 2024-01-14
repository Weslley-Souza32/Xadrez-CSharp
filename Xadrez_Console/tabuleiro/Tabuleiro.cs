namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[colunas, linhas];
        }

        /// <summary>
        /// Este método retonar uma peça para que eu possa acessar em outra classe.
        /// </summary>
        /// <param name="linha">coloca uma peça na linha</param>
        /// <param name="coluna">coloca uma peça na coluna</param>
        /// <returns> retorna uma peça do xadres colocando ela na linha e na coluna do tabuleiro</returns>
        public Peca peca (int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca ( Posicao pos)
        {
            return pecas [pos.linha, pos.coluna];
        }

        /// <summary>
        /// Esté método testa se existe uma peça em uma dada posição.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        /// <summary>
        /// Colocando uma peça na matriz pecas do nosso tabuleiro
        /// </summary>
        /// <param name="p">Retorna nossa peça da classe Peca</param>
        /// <param name="pos">Acessa a linha e a coluna colocando a peça de xadrez na posicão que informamos.</param>
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        /// <summary>
        /// Retirar uma peça do tabuleiro.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        /// <summary>
        /// Método testa se a posição e valida ou não.
        /// </summary>
        /// <param name="pos">Verifica se a posicao da linha e da coluna e valida.</param>
        /// <returns>false: não está valida; true: está valida</returns>
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// O método recerá uma posição passada por argumento e verifica se ela esta valida se não estiver será lançada uma excessão.
        /// </summary>
        /// <param name="pos"></param>
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
