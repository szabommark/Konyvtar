**Modellezzük egy könyvtár működését!**

Egy könyvtár nyilvántartja a kikölcsönözhető könyveit (ismert címe, szerzője, kiadója, ISBN száma), és a hozzá beiratkozott tagokat (ismert a neve, címe, igazolványszáma), és. A tagok kiiratkozhatnak a könyvtárból, ha már nincs náluk kikölcsönzött könyv. A könyvtár beszerezhet, illetve leselejtezhet könyveket.

Egy tag egy alkalommal több könyvet is kikölcsönözhet, de egyszerre ötnél több könyv nem lehet nála. A kikölcsönzött könyveket több részletben is visszahozhatja, de ügyelni kell a kölcsönzési idő betartására. Egy könyv kölcsönzési pótdíja a kölcsönzés lejárati idejétől számított napok számának, valamint a könyv példányszámától és műfajától függő együtthatónak szorzata.

| napi pótdíj | sok példány | kevés példány | ritkaság |
| :--- | :--- | :--- | :--- |
| természettudományi | 20 | 60 | 100 |
| szépirodalmi | 10 | 30 | 50 |
| ifjúsági | 5 | 10 | 30 |

a. A könyvtár tudjon beszerezni, és leselejtezni könyveket; új személy be tudjon iratkozni a könyvtárba, illetve ki tudjon lépni, ha nincs hátraléka; egy tag kikölcsönözhesse az általa megadott című könyvek közül azokat, amelyek elérhetők (feltéve, hogy nincs tartozása); visszahozhasson kikölcsönzött könyveket; befizethesse tagdíját vagy az esetleges pótdíját.
b. Van-e hátraléka egy adott tagnak: kell-e tagdíjat és/vagy pótdíjat fizetnie, és mennyit?
c. Megtalálható-e a könyvtárban egy adott című könyv, és kikölcsönözhető-e?
d. Tagja-e egy adott nevű személy a könyvtárnak?

Készítsen használati eset diagramot! Ebben jelenjenek meg használati esetként a könyvtár fontosabb metódusainak nevei. Adjon meg a fenti feladathoz egy olyan objektum diagramot, amely egy könyvtárnak öt könyvét, és két könyvtári tagját mutatja, valamint három kölcsönzési esemény, amelyekről leolvasható, hogy melyik tag milyen könyveket tart éppen magánál: az egyik tag kétszer kölcsönzött, először egy, majd két könyvet, a másik tag egyszer egy könyvet. Egy könyv legyen a könyvtárban. Egészítse ezt ki kommunikációs diagrammá!

Készítse el egy kölcsönzés objektum állapotgépét! Különböztesse meg az „üres”, a „köztes”, és a „teli” állapotokat aszerint, hogy 0, 1-4, vagy 5 könyv van a kölcsönzés eseményhez rendelve. Az állapot-átmeneteket megvalósító tevékenységeket majd a kölcsönzés osztály metódusaiként definiálhatja.

Rajzolja fel a feladat osztály diagramját! Felteheti, hogy a rejtett adattagokhoz mindig tartozik egy publikus getter: ha mégsem, akkor azt a „secret” megjegyzéssel jelölje. Egészítse ki az osztálydiagramot az objektum-kapcsolatokat létrehozó metódusokkal, valamint a feladat kérdéseit megválaszoló metódusokkal. A metódusok leírása legyen minél tömörebb (például ciklusok helyett a megfelelő algoritmus minta specifikációs jelölését használja). Használjon tervezési mintákat, és mutasson rá, hogy hol melyiket alkalmazta. Egy könyv pótdíját a késedelmi idő és a könyv fajtájától (természettudományos, szépirodalmi, ifjúsági), valamint a könyvtárban található példányszámtól (sok, kevés, ritka) függő szorzótényező határozza meg.

Implementálja a modellt! Szerkesszen olyan szöveges állományt, amelyből fel lehet populálni egy könyvtár könyveit, könyvtári tagjait, néhány kölcsönzést és könyv visszahozást. Válaszoljuk meg a b. c. d. kérdéseket. Készítsen teszteseteket, néhánynak rajzolja fel a szekvencia diagramját, és hozzon létre ezek kipróbálására automatikus tesztkörnyezetet!
