using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Test
{
    [TestClass]
    public class StringCalculatorTests
    {
        //SUT
        private StringCalculator _calculator;

        [TestInitialize]
        public void Init()
        {
            _calculator = new StringCalculator();
        }


        [TestMethod]
        public void Deve_retornar_0_caso_entrada_seja_vazia()
        {
            //arrange
            string input = "";

            //act
            int result = _calculator.Add(input);

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Deve_retornar_1_caso_entrada_seja_1()
        {
            //arrange
            string input = "1";

            //act
            int result = _calculator.Add(input);

            //assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Deve_retornar_o_numero_fornecido_caso_entrada_tenha_um_numero()
        {
            //arrange
            string input = "8";
            string input2 = "2";
            string input3 = "4";
            string input4 = "0";

            //act
            int result = _calculator.Add(input);
            int result2 = _calculator.Add(input2);
            int result3 = _calculator.Add(input3);
            int result4 = _calculator.Add(input4);

            //assert
            Assert.AreEqual(8, result);
            Assert.AreEqual(2, result2);
            Assert.AreEqual(4, result3);
            Assert.AreEqual(0, result4);
        }

        [TestMethod]
        public void Deve_retornar_soma_de_dois_numeros()
        {
            //arrange
            string input = "1,2";

            //act
            int result = _calculator.Add(input);

            //assert
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void Deve_retornar_5_ao_somar_3_e_2()
        {
            //arrange
            string input = "3,2";

            //act
            int result = _calculator.Add(input);

            //assert
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Deve_retornar_3_ao_somar_1_1_e_1()
        {
            //arrange
            string input = "1,1,1";

            //act
            int result = _calculator.Add(input);

            //assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Deve_retornar_a_soma_de_n_numeros()
        {
            //arrange
            string input = "1,2,3,4,5";

            //act
            int result = _calculator.Add(input);

            //assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Deve_retornar_a_soma_de_dois_numeros_separados_por_quebra_de_linha()
        {
            //arrange
            string input = "1\n2";

            //act
            int result = _calculator.Add(input);

            //assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Deve_retornar_a_soma_tres_numeros_separados_por_virgula_e_quebra_e_linha()
        {
            //arrange
            string input = "1\n2,3";
            string input2 = "4\n5,6";
            string input3 = "4\n5,6,5";

            //act
            int result = _calculator.Add(input);
            int result2 = _calculator.Add(input2);
            int result3 = _calculator.Add(input3);

            //assert
            Assert.AreEqual(6, result);
            Assert.AreEqual(15, result2);
            Assert.AreEqual(20, result3);
        }

        [TestMethod]
        public void Deve_retornar_3_com_um_delimitador_customizado_sendo_ponto_e_virgula()
        {
            //arrange
            string input = "//;\n1;2";

            //act
            int result = _calculator.Add(input);

            // assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Deve_retornar_3_quando_delimitador_for_igual_a_hifen()
        {
            //arrange
            string input = "//-\n2-2";

            //act
            int result = _calculator.Add(input);

            // assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Deve_retornar_a_soma_com_2_numeros_e_delimitador_personalizado()
        {
            //arrange
            string input = "//*\n2*2";

            //act
            int result = _calculator.Add(input);

            // assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Deve_retornar_a_soma_com_n_numeros_e_delimitador_com_dois_caracteres()
        {
            //arrange
            string input = "//**\n2**2";

            //act
            int result = _calculator.Add(input);

            // assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Deve_retornar_uma_excessao_caso_houver_numeros_negativos()
        {
            //arrange
            string input = "//**\n-2**2";
            int result = 0;
            try
            {
                //act
                result = _calculator.Add(input);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("-2", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail($"Método não retornou exceção do tipo {nameof(ArgumentException)}");
            }
        }

        [TestMethod]
        public void Deve_retornar_uma_excessao_caso_houver_um_numero_negativo()
        {
            //arrange
            string input = "2,-3";
            int result = 0;
            try
            {
                //act
                result = _calculator.Add(input);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("-3", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail($"Método não retornou exceção do tipo {nameof(ArgumentException)}");
            }
        }

        [TestMethod]
        public void Deve_retornar_uma_excessao_caso_existam_dois_numeros_negativos()
        {
            //arrange
            string input = "-2,-3";
            int result = 0;
            try
            {
                //act
                result = _calculator.Add(input);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("-2,-3", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail($"Método não retornou exceção do tipo {nameof(ArgumentException)}");
            }
        }

        [TestMethod]
        public void Deve_retornar_excecao_quando_delimitador_for_hifen_e_existir_numero_negativo()
        {
            //arrange
            string input = "//-\n3--3";
            int result = 0;

            try
            {
                //act
                result = _calculator.Add(input);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("-3", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail($"Método não retornou exceção do tipo {nameof(ArgumentException)}");
            }
        }

        //[TestMethod]
        //public void Deve_retornar_excecao_quando_delimitador_for_hifen_e_existir_um_numero_negativo()
        //{
        //    //arrange
        //    string input = "//-\n3--5";
        //    int result = 0;

        //    try
        //    {
        //        //act
        //        result = _calculator.Add(input);
        //        Assert.Fail();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Assert.AreEqual("-5", ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        Assert.Fail($"Método não retornou exceção do tipo {nameof(ArgumentException)}");
        //    }
        //}
    }
}
