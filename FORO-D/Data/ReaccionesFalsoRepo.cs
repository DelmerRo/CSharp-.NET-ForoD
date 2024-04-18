using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class ReaccionesFalsoRepo
    {
        public static List<Reaccion> GetReacciones()
        {
            Reaccion reac1 = new () { RespuestaId=9, MiembroId =6,Fecha= new(2022, 02, 09, 07, 53, 50), MeGusta=true };
            Reaccion reac2 = new() { RespuestaId = 10, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac3 = new() { RespuestaId = 12, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac4 = new() { RespuestaId = 14, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac5 = new() { RespuestaId = 15, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac6 = new() { RespuestaId = 16, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac7 = new() { RespuestaId = 17, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac8 = new() { RespuestaId = 20, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac9 = new() { RespuestaId = 21, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac10 = new() { RespuestaId = 22, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };

            Reaccion reac11 = new() { RespuestaId = 23, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac12 = new() { RespuestaId = 24, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac13 = new() { RespuestaId = 25, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac14 = new() { RespuestaId = 30, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac15 = new() { RespuestaId = 31, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac16 = new() { RespuestaId = 32, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac17 = new() { RespuestaId = 33, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac18 = new() { RespuestaId = 36, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac19 = new() { RespuestaId = 37, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac20 = new() { RespuestaId = 38, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };

            Reaccion reac21 = new() { RespuestaId = 39, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac22 = new() { RespuestaId = 42, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac23 = new() { RespuestaId = 43, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac24 = new() { RespuestaId = 44, MiembroId = 6, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac25 = new() { RespuestaId = 1, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac26 = new() { RespuestaId = 2, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac27 = new() { RespuestaId = 5, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac28 = new() { RespuestaId = 6, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac29 = new() { RespuestaId = 7, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac30 = new() { RespuestaId = 14, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };

            Reaccion reac31 = new() { RespuestaId = 16, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac32 = new() { RespuestaId = 18, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac33 = new() { RespuestaId = 19, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac34 = new() { RespuestaId = 20, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac35 = new() { RespuestaId = 21, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac36 = new() { RespuestaId = 26, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac37 = new() { RespuestaId = 28, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac38 = new() { RespuestaId = 29, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac39 = new() { RespuestaId = 30, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac40 = new() { RespuestaId = 33, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
        
            Reaccion reac41 = new() { RespuestaId = 34, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac42 = new() { RespuestaId = 35, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac43 = new() { RespuestaId = 38, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac44 = new() { RespuestaId = 41, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac45 = new() { RespuestaId = 44, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac46 = new() { RespuestaId = 45, MiembroId = 7, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac47 = new() { RespuestaId = 2, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac48 = new() { RespuestaId = 4, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac49 = new() { RespuestaId = 5, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac50 = new() { RespuestaId = 6, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };

            Reaccion reac51 = new() { RespuestaId = 7, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac52 = new() { RespuestaId = 8, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac53 = new() { RespuestaId = 9, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac54 = new() { RespuestaId = 10, MiembroId =8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac55 = new() { RespuestaId = 11, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac56 = new() { RespuestaId = 13, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac57 = new() { RespuestaId = 20, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac58 = new() { RespuestaId = 21, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac59 = new() { RespuestaId = 24, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac60 = new() { RespuestaId = 25, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };

            Reaccion reac61 = new() { RespuestaId = 27, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac62 = new() { RespuestaId = 28, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac63 = new() { RespuestaId = 30, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac64 = new() { RespuestaId =32, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac65 = new() { RespuestaId = 33, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = true };
            Reaccion reac66 = new() { RespuestaId = 34, MiembroId = 8, Fecha = new(2022, 02, 09, 07, 53, 50), MeGusta = false };
            Reaccion reac67 = new() { RespuestaId = 35, MiembroId = 8, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac68 = new() { RespuestaId = 38, MiembroId = 8, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac69 = new() { RespuestaId = 39, MiembroId = 8, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac70 = new() { RespuestaId = 40, MiembroId = 8, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };

            Reaccion reac71 = new() { RespuestaId = 41, MiembroId = 8, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac72 = new() { RespuestaId = 44, MiembroId = 8, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac73 = new() { RespuestaId = 45, MiembroId = 8, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac74 = new() { RespuestaId = 1, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac75 = new() { RespuestaId = 2, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac76 = new() { RespuestaId = 3, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac77 = new() { RespuestaId = 4, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac78 = new() { RespuestaId = 8, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac79 = new() { RespuestaId = 9, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac80 = new() { RespuestaId = 12, MiembroId =9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };

            Reaccion reac81 = new() { RespuestaId = 13, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac82 = new() { RespuestaId = 14, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac83 = new() { RespuestaId = 17, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac84 = new() { RespuestaId = 26, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac85 = new() { RespuestaId = 27, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac86 = new() { RespuestaId = 31, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac87 = new() { RespuestaId = 33, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
            Reaccion reac88 = new() { RespuestaId = 34, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac89 = new() { RespuestaId = 35, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = false };
            Reaccion reac90 = new() { RespuestaId = 36, MiembroId = 9, Fecha = new(2022, 02, 09, 08, 53, 50), MeGusta = true };
        
            Reaccion reac91 = new() { RespuestaId = 37, MiembroId = 9, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac92 = new() { RespuestaId = 39, MiembroId = 9, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac93 = new() { RespuestaId = 40, MiembroId = 9, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac94 = new() { RespuestaId = 41, MiembroId = 9, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac95 = new() { RespuestaId = 42, MiembroId = 9, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac96 = new() { RespuestaId = 43, MiembroId = 9, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac97 = new() { RespuestaId = 1, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac98 = new() { RespuestaId = 8, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac99 = new() { RespuestaId = 9, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac100 = new() { RespuestaId = 11, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };

            Reaccion reac101 = new() { RespuestaId = 13, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac102 = new() { RespuestaId = 14, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac103 = new() { RespuestaId = 15, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac104= new() { RespuestaId = 18, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac105 = new() { RespuestaId = 20, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac106 = new() { RespuestaId = 22, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac107 = new() { RespuestaId = 23, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac108 = new() { RespuestaId = 25, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac109 = new() { RespuestaId = 35, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac110 = new() { RespuestaId = 36, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };

            Reaccion reac111 = new() { RespuestaId = 37, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac112 = new() { RespuestaId = 41, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac113 = new() { RespuestaId = 43, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac114 = new() { RespuestaId = 45, MiembroId = 10, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac115 = new() { RespuestaId = 1, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac116 = new() { RespuestaId = 2, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac117 = new() { RespuestaId = 5, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac118 = new() { RespuestaId =8, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac119 = new() { RespuestaId = 9, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac120 = new() { RespuestaId = 13, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };

            Reaccion reac121 = new() { RespuestaId = 14, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac122 = new() { RespuestaId = 15, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac123 = new() { RespuestaId = 16, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac124 = new() { RespuestaId = 18, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac125 = new() { RespuestaId = 19, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac126 = new() { RespuestaId = 24, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac127 = new() { RespuestaId = 40, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac128 = new() { RespuestaId = 41, MiembroId = 11, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac129 = new() { RespuestaId = 1, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac130 = new() { RespuestaId = 2, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };

            Reaccion reac131 = new() { RespuestaId = 11, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac132 = new() { RespuestaId = 13, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac133 = new() { RespuestaId = 14, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac134 = new() { RespuestaId = 21, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac135 = new() { RespuestaId = 25, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac136 = new() { RespuestaId =26, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac137 = new() { RespuestaId = 28, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac138 = new() { RespuestaId = 33, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac139 = new() { RespuestaId = 34, MiembroId = 12, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac140 = new() { RespuestaId = 1, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };

            Reaccion reac141 = new() { RespuestaId = 8, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac142 = new() { RespuestaId = 9, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac143 = new() { RespuestaId = 13, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac144 = new() { RespuestaId = 14, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            Reaccion reac145 = new() { RespuestaId = 21, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac146 = new() { RespuestaId = 34, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = false };
            Reaccion reac147 = new() { RespuestaId = 40, MiembroId = 13, Fecha = new(2022, 02, 09, 09, 53, 50), MeGusta = true };
            

            List<Reaccion> reacciones = new ();
            reacciones.Add(reac1);
            reacciones.Add(reac2);
            reacciones.Add(reac3);
            reacciones.Add(reac4);
            reacciones.Add(reac5);
            reacciones.Add(reac6);
            reacciones.Add(reac7);
            reacciones.Add(reac8);
            reacciones.Add(reac9);
            reacciones.Add(reac10);

            reacciones.Add(reac11);
            reacciones.Add(reac12);
            reacciones.Add(reac13);
            reacciones.Add(reac14);
            reacciones.Add(reac15);
            reacciones.Add(reac16);
            reacciones.Add(reac17);
            reacciones.Add(reac18);
            reacciones.Add(reac19);
            reacciones.Add(reac20);

            reacciones.Add(reac21);
            reacciones.Add(reac22);
            reacciones.Add(reac23);
            reacciones.Add(reac24);
            reacciones.Add(reac25);
            reacciones.Add(reac26);
            reacciones.Add(reac27);
            reacciones.Add(reac28);
            reacciones.Add(reac29);
            reacciones.Add(reac30);

            reacciones.Add(reac31);
            reacciones.Add(reac32);
            reacciones.Add(reac33);
            reacciones.Add(reac34);
            reacciones.Add(reac35);
            reacciones.Add(reac36);
            reacciones.Add(reac37);
            reacciones.Add(reac38);
            reacciones.Add(reac39);
            reacciones.Add(reac40);

            reacciones.Add(reac41);
            reacciones.Add(reac42);
            reacciones.Add(reac43);
            reacciones.Add(reac44);
            reacciones.Add(reac45);
            reacciones.Add(reac46);
            reacciones.Add(reac47);
            reacciones.Add(reac48);
            reacciones.Add(reac49);
            reacciones.Add(reac50);

            reacciones.Add(reac51);
            reacciones.Add(reac52);
            reacciones.Add(reac53);
            reacciones.Add(reac54);
            reacciones.Add(reac55);
            reacciones.Add(reac56);
            reacciones.Add(reac57);
            reacciones.Add(reac58);
            reacciones.Add(reac59);
            reacciones.Add(reac60);

            reacciones.Add(reac61);
            reacciones.Add(reac62);
            reacciones.Add(reac63);
            reacciones.Add(reac64);
            reacciones.Add(reac65);
            reacciones.Add(reac66);
            reacciones.Add(reac67);
            reacciones.Add(reac68);
            reacciones.Add(reac69);
            reacciones.Add(reac70);

            reacciones.Add(reac71);
            reacciones.Add(reac72);
            reacciones.Add(reac73);
            reacciones.Add(reac74);
            reacciones.Add(reac75);
            reacciones.Add(reac76);
            reacciones.Add(reac77);
            reacciones.Add(reac78);
            reacciones.Add(reac79);
            reacciones.Add(reac80);

            reacciones.Add(reac81);
            reacciones.Add(reac82);
            reacciones.Add(reac83);
            reacciones.Add(reac84);
            reacciones.Add(reac85);
            reacciones.Add(reac86);
            reacciones.Add(reac87);
            reacciones.Add(reac88);
            reacciones.Add(reac89);
            reacciones.Add(reac90);

            reacciones.Add(reac91);
            reacciones.Add(reac92);
            reacciones.Add(reac93);
            reacciones.Add(reac94);
            reacciones.Add(reac95);
            reacciones.Add(reac96);
            reacciones.Add(reac97);
            reacciones.Add(reac98);
            reacciones.Add(reac99);
            reacciones.Add(reac100);

            reacciones.Add(reac101);
            reacciones.Add(reac102);
            reacciones.Add(reac103);
            reacciones.Add(reac104);
            reacciones.Add(reac105);
            reacciones.Add(reac106);
            reacciones.Add(reac107);
            reacciones.Add(reac108);
            reacciones.Add(reac109);
            reacciones.Add(reac110);

            reacciones.Add(reac111);
            reacciones.Add(reac112);
            reacciones.Add(reac113);
            reacciones.Add(reac114);
            reacciones.Add(reac115);
            reacciones.Add(reac116);
            reacciones.Add(reac117);
            reacciones.Add(reac118);
            reacciones.Add(reac119);
            reacciones.Add(reac120);

            reacciones.Add(reac121);
            reacciones.Add(reac122);
            reacciones.Add(reac123);
            reacciones.Add(reac124);
            reacciones.Add(reac125);
            reacciones.Add(reac126);
            reacciones.Add(reac127);
            reacciones.Add(reac128);
            reacciones.Add(reac129);
            reacciones.Add(reac130);

            reacciones.Add(reac131);
            reacciones.Add(reac132);
            reacciones.Add(reac133);
            reacciones.Add(reac134);
            reacciones.Add(reac135);
            reacciones.Add(reac136);
            reacciones.Add(reac137);
            reacciones.Add(reac138);
            reacciones.Add(reac139);
            reacciones.Add(reac140);

            reacciones.Add(reac141);
            reacciones.Add(reac142);
            reacciones.Add(reac143);
            reacciones.Add(reac144);
            reacciones.Add(reac145);
            reacciones.Add(reac146);
            reacciones.Add(reac147);
 

            return reacciones;
        }
    }
}
