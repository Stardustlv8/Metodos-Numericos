﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;
using System.Collections;
using System.Windows.Forms;

namespace Roots
{
    public class Biseccion
    {

        public string ValStarta1 { get; set; }
        public string ValStartb1 { get; set; }
        public double Tolerance { get; set; }
        public int Iteration { get; set; }
        public string Expresion { get; set; }
        public string Derivate { get; set; }
        public double Root { get; set; }
        private Evaluador evaluator;

        public Biseccion()
        {
            evaluator = new Evaluador();
            evaluator.Presition = 7;
        }

        public LinkedList<string[]> solucion()
        {
            double ValStarta=evaluator.EvalVar(ValStarta1);
            double ValStartb=evaluator.EvalVar(ValStartb1);
            double pm;
            double fa;
            double fb;
            double fpm;
            int it = 0;

            
            LinkedList<string[]> Resultado = new LinkedList<string[]>();

            do
            {
                pm = ValStarta +( (ValStartb - ValStarta) / 2);
                fa = evaluator.EvalFunction(Expresion, ValStarta);
                fb = evaluator.EvalFunction(Expresion, ValStartb);
                fpm = evaluator.EvalFunction(Expresion, pm);

                //data.Rows.Add(it, ValStarta, ValStartb, pm, fa, fb, fpm); saludos
                string[] IterationVals = new string[7];

                IterationVals[0] = Convert.ToString(it);
                IterationVals[1] = Convert.ToString(ValStarta);
                IterationVals[2] = Convert.ToString(ValStartb);
                IterationVals[3] = Convert.ToString(pm);
                IterationVals[4] = Convert.ToString(fa);
                IterationVals[5] = Convert.ToString(fb);
                IterationVals[6] = Convert.ToString(fpm);

                Resultado.AddLast(IterationVals);

                if (fpm * fa < 0)
                {
                    ValStartb = pm;
                }
                else if(fpm * fb < 0)
                {
                    ValStarta = pm;
                }
                else
                {
                    pm = -1;
                    break;
                }
                it++;
            } while (it <= Iteration && Tolerance < Math.Abs( ((ValStartb-ValStarta)/2) ));

            Root = pm;

            return Resultado;
        }
    }
}

