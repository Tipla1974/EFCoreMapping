using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class SeedingASSWerknemer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ASSWerknemers1",
                columns: new[] { "WerknemerId", "Familienaam", "OversteId", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Szavay", null, "Agnes" },
                    { 102, "Mayer", null, "Leonardo" },
                    { 105, "Hradecka", null, "Lucie" },
                    { 108, "Safin", null, "Marat" },
                    { 111, "Baghdatis", null, "Marcos" },
                    { 114, "Jose Martinez Sanchez", null, "Maria" },
                    { 117, "Cilic", null, "Marin" },
                    { 120, "Bartoli", null, "Marion" },
                    { 123, "Johansson", null, "Mathilde" },
                    { 126, "Llodra", null, "Michael" },
                    { 129, "Niculescu", null, "Monica" },
                    { 132, "Dechy", null, "Nathalie" },
                    { 135, "Kiefer", null, "Nicolas" },
                    { 138, "Davydenko", null, "Nikolay" },
                    { 141, "Hernandez", null, "Oscar" },
                    { 144, "Schnyder", null, "Patty" },
                    { 147, "Parmentier", null, "Pauline" },
                    { 150, "Kohlschreiber", null, "Philipp" },
                    { 192, "Zvonareva", null, "Vera" },
                    { 189, "King", null, "Vania" },
                    { 186, "Haas", null, "Tommy" },
                    { 183, "Bellucci", null, "Thomaz" },
                    { 180, "Paszek", null, "Tamira" },
                    { 177, "Kuznetsova", null, "Svetlana" },
                    { 99, "Zakopalova", null, "Klara" },
                    { 174, "Cirstea", null, "Sorana" },
                    { 168, "Williams", null, "Serena" },
                    { 165, "Querrey", null, "Samuel" },
                    { 162, "De Los Rios", null, "Rossana" },
                    { 159, "Vinci", null, "Roberta" },
                    { 156, "Gasquet", null, "Richard" },
                    { 153, "Stepanek", null, "Radek" },
                    { 171, "Peng", null, "Shuai" },
                    { 195, "Troicki", null, "Viktor" },
                    { 96, "Bondarenko", null, "Kateryna" },
                    { 90, "Monaco", null, "Juan" },
                    { 2, "Radwanska", null, "Agnieszka" },
                    { 3, "Calleri", null, "Agustin" },
                    { 6, "Montanes", null, "Albert" },
                    { 9, "Kleybanova", null, "Alisa" },
                    { 12, "Bondarenko", null, "Alona" },
                    { 15, "Medina Garrigues", null, "Anabel" },
                    { 18, "Beck", null, "Andreas" },
                    { 21, "Roddick", null, "Andy" },
                    { 24, "Keothavong", null, "Anne" },
                    { 27, "Morita", null, "Ayumi" },
                    { 30, "Phau", null, "Bjorn" },
                    { 33, "Pin", null, "Camille" },
                    { 36, "Wozniacki", null, "Caroline" },
                    { 39, "Gimeno", null, "Daniel" },
                    { 42, "Nalbandian", null, "David" },
                    { 45, "Safina", null, "Dinara" },
                    { 48, "Sela", null, "Dudi" },
                    { 87, "Tsonga", null, "Jo-Wilfried" },
                    { 84, "Chardy", null, "Jeremy" },
                    { 81, "Groth", null, "Jarmila" },
                    { 78, "Hernych", null, "Jan" },
                    { 75, "Benesova", null, "Iveta" },
                    { 72, "Kunitsyn", null, "Igor" },
                    { 93, "Melzer", null, "Jurgen" },
                    { 69, "Canas", null, "Guillermo" },
                    { 63, "Gil", null, "Frederico" },
                    { 60, "Pennetta", null, "Flavia" },
                    { 57, "Lopez", null, "Feliciano" },
                    { 54, "Gulbis", null, "Ernests" },
                    { 51, "Makarova", null, "Ekaterina" },
                    { 50, "Schwank", null, "Eduardo" },
                    { 66, "Muller", null, "Gilles" },
                    { 198, "Wickmayer", null, "Yanina" }
                });

            migrationBuilder.InsertData(
                table: "ASSWerknemers1",
                columns: new[] { "WerknemerId", "Familienaam", "OversteId", "Voornaam" },
                values: new object[,]
                {
                    { 4, "Sugiyama", 1, "Ai" },
                    { 185, "Berdych", 36, "Tomas" },
                    { 187, "Robredo", 36, "Tommy" },
                    { 197, "Odesnik", 36, "Wayne" },
                    { 70, "Garcia-Lopez", 39, "Guillermo" },
                    { 55, "Korolev", 50, "Evgueni" },
                    { 56, "Santoro", 50, "Fabrice" },
                    { 101, "Vliegen", 50, "Kristof" },
                    { 128, "Youzhny", 50, "Mikhail" },
                    { 133, "Almagro", 50, "Nicolas" },
                    { 161, "Federer", 36, "Roger" },
                    { 52, "Dementieva", 51, "Elena" },
                    { 184, "Bacsinszky", 51, "Timea" },
                    { 74, "Navarro-Pastor", 57, "Ivan" },
                    { 88, "Carlos Ferrero", 57, "Juan" },
                    { 98, "Flipkens", 57, "Kirsten" },
                    { 100, "Barrois", 57, "Kristina" },
                    { 134, "Devilder", 57, "Nicolas" },
                    { 169, "Bremond", 57, "Severine" },
                    { 196, "Razzano", 57, "Virginie" },
                    { 179, "Tanasugarn", 81, "Tamarine" },
                    { 79, "Tipsarevic", 51, "Janko" },
                    { 157, "Ginepri", 36, "Robby" },
                    { 149, "Kvitova", 36, "Petra" },
                    { 142, "Andujar", 36, "Pablo" },
                    { 5, "Amanmuradova", 1, "Akgul" },
                    { 7, "Martin", 1, "Alberto" },
                    { 10, "Cornet", 1, "Alize" },
                    { 22, "Chakvetadze", 1, "Anna" },
                    { 44, "Junqueira", 2, "Diego" },
                    { 34, "Suarez Navarro", 3, "Carla" },
                    { 46, "Tursunov", 3, "Dmitry" },
                    { 59, "Verdasco", 6, "Fernando" },
                    { 37, "Dellacqua", 9, "Casey" },
                    { 16, "Pavlyuchenkova", 15, "Anastasia" },
                    { 28, "Zahlavova Strycova", 15, "Barbora" },
                    { 91, "Coin", 21, "Julie" },
                    { 112, "Fish", 21, "Mardy" },
                    { 73, "Ljubicic", 33, "Ivan" },
                    { 143, "Mayr", 33, "Patricia" },
                    { 200, "Chan", 33, "Yung-Jan" },
                    { 53, "Vesnina", 36, "Elena" },
                    { 61, "Serra", 36, "Florent" },
                    { 125, "Czink", 36, "Melinda" },
                    { 131, "Petrova", 36, "Nadia" },
                    { 136, "Massu", 36, "Nicolas" },
                    { 182, "Gabashvili", 81, "Teimuraz" },
                    { 104, "Dominguez Lino", 99, "Lourdes" }
                });

            migrationBuilder.InsertData(
                table: "ASSWerknemers1",
                columns: new[] { "WerknemerId", "Familienaam", "OversteId", "Voornaam" },
                values: new object[,]
                {
                    { 11, "Kudryavtseva", 5, "Alla" },
                    { 92, "Benneteau", 55, "Julien" },
                    { 155, "Schuettler", 61, "Rainer" },
                    { 121, "Koryttseva", 61, "Mariya" },
                    { 110, "Granollers", 61, "Marcel" },
                    { 65, "Voskoboeva", 61, "Galina" },
                    { 188, "Pironkova", 73, "Tsvetana" },
                    { 175, "Wawrinka", 73, "Stanislas" },
                    { 95, "Srebotnik", 73, "Katarina" },
                    { 107, "Rybarikova", 91, "Magdalena" },
                    { 97, "Nishikori", 28, "Kei" },
                    { 113, "Ani", 16, "Maret" },
                    { 85, "Zheng", 16, "Jie" },
                    { 191, "Dushevina", 37, "Vera" },
                    { 173, "Arvidsson", 46, "Sofia" },
                    { 160, "Soderling", 46, "Robin" },
                    { 148, "Cetkovska", 46, "Petra" },
                    { 116, "Sharapova", 46, "Maria" },
                    { 115, "Kirilenko", 46, "Maria" },
                    { 49, "Gallovits", 46, "Edina" },
                    { 23, "Groenefeld", 22, "Anna-Lena" },
                    { 31, "Reynolds", 10, "Bobby" },
                    { 29, "Mattek-Sands", 10, "Bethanie" },
                    { 13, "Mauresmo", 10, "Amelie" },
                    { 58, "Gonzalez", 7, "Fernando" },
                    { 8, "Wozniak", 7, "Aleksandra" },
                    { 130, "Li", 5, "Na" },
                    { 20, "Murray", 5, "Andy" },
                    { 137, "Vaidisova", 55, "Nicole" },
                    { 176, "Cohen-Aloro", 100, "Stephanie" }
                });

            migrationBuilder.InsertData(
                table: "ASSWerknemers1",
                columns: new[] { "WerknemerId", "Familienaam", "OversteId", "Voornaam" },
                values: new object[,]
                {
                    { 14, "Ivanovic", 11, "Ana" },
                    { 181, "Garbin", 49, "Tathiana" },
                    { 164, "Stosur", 49, "Samantha" },
                    { 158, "Kendrick", 49, "Robert" },
                    { 124, "Gonzalez", 49, "Maximo" },
                    { 118, "Erakovic", 49, "Marina" },
                    { 83, "Jankovic", 49, "Jelena" },
                    { 80, "Nieminen", 49, "Jarkko" },
                    { 38, "Rochus", 23, "Christophe" },
                    { 154, "Nadal", 31, "Rafael" },
                    { 82, "Dokic", 31, "Jelena" },
                    { 89, "Martin Del Potro", 65, "Juan" },
                    { 68, "Dulko", 31, "Gisela" },
                    { 41, "Ferrer", 31, "David" },
                    { 40, "Hantuchova", 31, "Daniela" },
                    { 109, "Gicquel", 29, "Marc" },
                    { 86, "Acasuso", 29, "Jose" },
                    { 71, "Andreev", 29, "Igor" },
                    { 64, "Monfils", 29, "Gael" },
                    { 17, "Yakimova", 13, "Anastasiya" },
                    { 43, "Gremelmayr", 8, "Denis" },
                    { 62, "Schiavone", 20, "Francesca" },
                    { 25, "Rezai", 11, "Aravane" },
                    { 67, "Simon", 31, "Gilles" },
                    { 194, "Azarenka", 65, "Victoria" }
                });

            migrationBuilder.InsertData(
                table: "ASSWerknemers1",
                columns: new[] { "WerknemerId", "Familienaam", "OversteId", "Voornaam" },
                values: new object[,]
                {
                    { 35, "Moya", 25, "Carlos" },
                    { 140, "Govortsova", 41, "Olga" },
                    { 139, "Djokovic", 41, "Novak" },
                    { 106, "Safarova", 41, "Lucie" },
                    { 151, "Petzschner", 71, "Philipp" },
                    { 146, "Mathieu", 71, "Paul-Henri" },
                    { 199, "Lu", 17, "Yen-Hsun" },
                    { 26, "Clement", 17, "Arnaud" },
                    { 19, "Seppi", 17, "Andreas" },
                    { 193, "Hanescu", 43, "Victor" },
                    { 178, "Bammer", 43, "Sybille" },
                    { 172, "Bolelli", 43, "Simone" },
                    { 163, "Lisicki", 43, "Sabine" },
                    { 152, "Starace", 43, "Potito" },
                    { 127, "Zverev", 43, "Michael" },
                    { 103, "Hewitt", 43, "Lleyton" },
                    { 170, "Peer", 25, "Shahar" },
                    { 167, "Errani", 25, "Sara" },
                    { 94, "Kanepi", 25, "Kaia" },
                    { 76, "Karlovic", 25, "Ivo" },
                    { 145, "Capdeville", 41, "Paul" },
                    { 190, "Williams", 41, "Venus" }
                });

            migrationBuilder.InsertData(
                table: "ASSWerknemers1",
                columns: new[] { "WerknemerId", "Familienaam", "OversteId", "Voornaam" },
                values: new object[,]
                {
                    { 122, "Vassallo-Arguello", 103, "Martin" },
                    { 32, "Dabul", 26, "Brian" },
                    { 47, "Cibulkova", 26, "Dominika" },
                    { 77, "Blake", 26, "James" },
                    { 119, "Ancic", 26, "Mario" },
                    { 166, "Mirza", 26, "Sania" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ASSWerknemers1",
                keyColumn: "WerknemerId",
                keyValue: 1);
        }
    }
}
