DROP TABLE JENIS_MENU CASCADE CONSTRAINT PURGE;
DROP TABLE MENU CASCADE CONSTRAINT PURGE;
DROP TABLE JABATAN CASCADE CONSTRAINT PURGE;
DROP TABLE KARYAWAN CASCADE CONSTRAINT PURGE;
DROP TABLE ABSENSI CASCADE CONSTRAINT PURGE;
DROP TABLE D_ABSENSI CASCADE CONSTRAINT PURGE;
DROP TABLE PELANGGAN CASCADE CONSTRAINT PURGE;
DROP TABLE RESERVATION CASCADE CONSTRAINT PURGE;
DROP TABLE TRANSAKSI CASCADE CONSTRAINT PURGE;
DROP TABLE D_TRANSAKSI CASCADE CONSTRAINT PURGE;


create table jenis_menu(
	ID NUMBER PRIMARY KEY,
	KODE_JENIS VARCHAR2(5) NOT NULL,
	NAMA_JENIS VARCHAR(50) NOT NULL
);

create table menu(
	ID NUMBER PRIMARY KEY,
	ID_JENIS_MENU NUMBER REFERENCES JENIS_MENU(ID),
	KODE_MENU VARCHAR2(5) NOT NULL,
	NAMA_MENU VARCHAR2(30) NOT NULL,
	STATUS NUMBER NOT NULL CHECK(STATUS = 0 OR STATUS = 1),
	HARGA NUMBER NOT NULL,
	DISKON NUMBER NOT NULL,
	HARGA_AKHIR NUMBER NOT NULL
);

CREATE TABLE JABATAN(
	ID NUMBER PRIMARY KEY,
	NAMA_JABATAN VARCHAR2(50) NOT NULL,
	GAJI_POKOK NUMBER NOT NULL
);

CREATE TABLE KARYAWAN(
	ID NUMBER PRIMARY KEY,
	ID_JABATAN NUMBER REFERENCES JABATAN(ID),
	USERNAME VARCHAR2(12) UNIQUE,
	PASS VARCHAR2(50) NOT NULL,
	NAMA_KARYAWAN VARCHAR2(50) NOT NULL,
	TGL_DAFTAR DATE NOT NULL
);

CREATE TABLE ABSENSI( 
	ID NUMBER PRIMARY KEY, 
	KODE_ABSEN VARCHAR2(5) NOT NULL, 
	TGL_ABSEN DATE NOT NULL
);

CREATE TABLE D_ABSENSI(
	ID NUMBER PRIMARY KEY,
	ID_ABSEN REFERENCES ABSENSI(ID),
	ID_KARYAWAN NUMBER REFERENCES KARYAWAN(ID),
	JAM_MASUK DATE NOT NULL,
	JAM_PULANG DATE
);

CREATE TABLE PELANGGAN( 
	ID NUMBER PRIMARY KEY,
	NAMA_PELANGGAN VARCHAR2(50) NOT NULL,
	ALAMAT VARCHAR2(50) NOT NULL,
	NO_TELP VARCHAR(12) UNIQUE
);


--Perkiraan keluar adalah waktu perkiraan pelanggan makan menggunakan meja tersebut, apabila waktu yang ditentukan sudah lewat maka meja akan dapat digunakan oleh pelanggan lain
--CREATE TABLE MEJA(
--	ID NUMBER PRIMARY KEY, 
--	ID_MEJA NUMBER,
--	WAKTU_PESAN TIMESTAMP NOT NULL,
--	PERKIRAAN_KELUAR TIMESTAMP NOT NULL
--);

CREATE TABLE RESERVATION(
	ID NUMBER PRIMARY KEY,
	ID_PELANGGAN NUMBER REFERENCES PELANGGAN(ID),
	ID_MEJA NUMBER,
	TGL_WAKTU_PEMESANAN DATE NOT NULL,
	WAKTU_PESAN TIMESTAMP NOT NULL,
	PERKIRAAN_KELUAR TIMESTAMP NOT NULL
);

CREATE TABLE TRANSAKSI(
	ID NUMBER PRIMARY KEY, 
	NOMOR_NOTA VARCHAR2(15) NOT NULL,
	ID_PELANGGAN NUMBER REFERENCES PELANGGAN(ID),
	NO_MEJA NUMBER CHECK(NO_MEJA > 0 and NO_MEJA < 11),
	NAMA_KASIR VARCHAR2(50) NOT NULL,
	METODE_PEMBAYARAN VARCHAR2(20) NOT NULL,
	TOTAL_PEMBELIAN NUMBER NOT NULL,
	POTONGAN_PEMBELIAN NUMBER NOT NULL,
	TOTAL_AKHIR NUMBER NOT NULL,
	TGL_PEMBELIAN DATE NOT NULL
);

CREATE TABLE D_TRANSAKSI(
	ID_TRANSAKSI NUMBER REFERENCES TRANSAKSI(ID),
	ID_MENU NUMBER REFERENCES MENU(ID),
	JUMLAH_MENU NUMBER NOT NULL
);

ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY';

INSERT INTO JENIS_MENU VALUES(1,'SE001','SEAFOOD');
INSERT INTO JENIS_MENU VALUES(2,'AY001','AYAM');
INSERT INTO JENIS_MENU VALUES(3,'SA001','SAYUR');
INSERT INTO JENIS_MENU VALUES(4,'MI001','MINUMAN');
INSERT INTO JENIS_MENU VALUES(5,'DE001','DESSERT');
INSERT INTO JENIS_MENU VALUES(6,'NA001','NASI');
INSERT INTO JENIS_MENU VALUES(7,'DI001','DIMSUM');
INSERT INTO JENIS_MENU VALUES(8,'MI001','MIE');

INSERT INTO MENU VALUES(1,1,'CG001','CUMI GORENG TEPUNG',1,35000,0,35000);
INSERT INTO MENU VALUES(2,1,'CG002','CUMI GORENG MENTEGA',1,20000,25,15000);
INSERT INTO MENU VALUES(17,1,'CA001','CUMI ASAM MANIS',1,30000,0,30000);
INSERT INTO MENU VALUES(3,2,'AB001','AYAM BAKAR',1,35000,10,31500);
INSERT INTO MENU VALUES(4,3,'CB001','CAH BABY KAILAN',1,37000,20,29600);
INSERT INTO MENU VALUES(5,3,'CK001','CAH KANGKUNG',0,21000,0,21000);
INSERT INTO MENU VALUES(6,4,'TT001','TEH TAWAR',1,6000,0,6000);
INSERT INTO MENU VALUES(7,4,'TM001','TEH MANIS',1,8000,0,8000);
INSERT INTO MENU VALUES(8,5,'EC001','ES CAMPUR',1,15000,0,15000);
INSERT INTO MENU VALUES(9,5,'ED001','ES DAWET',1,20000,0,20000);
INSERT INTO MENU VALUES(10,6,'NP001','NASI PUTIH',1,5000,0,5000);
INSERT INTO MENU VALUES(11,6,'NG001','NASI GORENG HONGKONG',1,26000,0,26000);
INSERT INTO MENU VALUES(12,4,'OT001','OCHA TEA',1,12000,0,12000);
INSERT INTO MENU VALUES(13,4,'CT001','CHRYSANTHEMUM TEA',1,30000,0,30000);
INSERT INTO MENU VALUES(14,4,'LH001','LO HAN KUO',1,30000,0,30000);
INSERT INTO MENU VALUES(15,7,'HA001','HAKAU',1,42000,0,42000);
INSERT INTO MENU VALUES(16,7,'KT001','KUOTIE',1,39000,0,39000);

-- MANAJER := Pemilik jabatan tertinggi di sistem restoran ini
-- KOKI := Tugas nya adalah menyiapkan pesanan dari pelayan untuk ditujukan kepada pelanggan
-- PELAYAN := Tugas nya adalah menyampaikan data permintaan pelanggan kepada koki
-- KASIR := Tugas nya adalah mencatat seluruh total biaya dari pesanan milik pelanggan
-- RESEPSIONIS := Tugas nya adalah memasukkan data Waiting List dari pelanggan
-- Gaji := gaji yang diberikan adalah gaji per jamnya
INSERT INTO JABATAN VALUES(1,'MANAJER',30000000);
INSERT INTO JABATAN VALUES(2,'KOKI',6000000);
INSERT INTO JABATAN VALUES(3,'PELAYAN',3500000);
INSERT INTO JABATAN VALUES(4,'KASIR',4000000);

INSERT INTO KARYAWAN VALUES(1,4,'PATKUS123','PatricKus','PATRICK KUSANAGI',TO_DATE('12/03/2018','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(2,3,'ANDREHEBAT','AndrianSug','ANDRIAN SUGIANTO',TO_DATE('12/03/2018','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(3,4,'LUKKY23','LukkyHar','LUKKY HARIYANTO',TO_DATE('24/12/2020','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(4,2,'STEVEN57','StevenLim','STEVEN LIEM',TO_DATE('24/01/2021','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(5,1,'ERICKN123','ErickN','ERICK NATHANAEL',TO_DATE('08/03/2021','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(6,4,'TEJE11','Teje123','NICHOLAS TJANDRA',TO_DATE('10/01/2021','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(7,1,'EDWINLO123','EdwinLo','EDWIN LO',TO_DATE('11/04/2020','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(8,4,'JASTINJ321','JastinJ','JASTIN JORDAN',TO_DATE('07/01/2021','DD/MM/YYYY'));

INSERT INTO PELANGGAN VALUES(1,'ANONIM', 'ANONIM', '012345678912');
INSERT INTO PELANGGAN VALUES(2,'BUDI DOREMI','JL. BUNTU 4 NO 7','087853111900');
INSERT INTO PELANGGAN VALUES(3,'MICHAEL ANGELO', 'JL. RAYA 6 NO 10','08972018528');
INSERT INTO PELANGGAN VALUES(4,'BIMA SAPUTRA','JL. NINJA 2 NO 17','08977205819');
INSERT INTO PELANGGAN VALUES(5,'BUDI FASOLLA','JL. JALAN 1 NO 27','087853111901');
INSERT INTO PELANGGAN VALUES(6,'MICHAEL DIANGELO', 'JL. JERUK 5 NO 13','08972018710');
INSERT INTO PELANGGAN VALUES(7,'AUREL AUDREY','JL. MANGGIS 4 NO 4','08971025724');
INSERT INTO PELANGGAN VALUES(8,'MICHAELA ARIFIN','JL. JAMBU 2 NO 11','087853111902');
INSERT INTO PELANGGAN VALUES(9,'MICHAEL TRIANGELO', 'JL. SEMANGKA 7 NO 90','08972123891');

INSERT INTO ABSENSI VALUES(1,'WMP22',TO_DATE('22/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(1,1,1,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(2,1,9,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(3,1,3,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(4,1,4,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(5,1,5,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(6,1,6,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(7,1,7,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(8,1,8,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(2,'HRM23',TO_DATE('23/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(9,2,1,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(10,2,2,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(11,2,3,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(12,2,4,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(13,2,6,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(14,2,7,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(15,2,8,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(16,2,9,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(3,'ASQ24',TO_DATE('24/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(17,3,2,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(18,3,3,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(19,3,4,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(20,3,5,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(21,3,6,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(22,3,7,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(23,3,8,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(24,3,9,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(4,'OPK25',TO_DATE('25/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(25,4,1,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(26,4,2,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(27,4,3,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(28,4,4,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(29,4,6,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(30,4,5,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(31,4,8,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(32,4,9,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(5,'QEF26',TO_DATE('26/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(33,5,1,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(34,5,2,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(35,5,3,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(36,5,4,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(37,5,6,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(38,5,7,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(39,5,8,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(40,5,9,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(6,'VSD27',TO_DATE('27/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(41,6,1,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(42,6,2,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(43,6,3,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(44,6,4,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(45,6,7,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(46,6,5,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(47,6,8,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(48,6,9,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(7,'MLZ28',TO_DATE('28/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(49,7,1,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(50,7,7,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(51,7,3,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(52,7,4,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(53,7,6,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(54,7,5,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(55,7,8,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(56,7,9,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(8,'EDF29',TO_DATE('29/05/2021','DD/MM/YYYY'));
INSERT INTO D_ABSENSI VALUES(57,8,1,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(58,8,2,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(59,8,7,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(60,8,4,TO_DATE('10:01:01','HH24:MI:SS'),TO_DATE('17:10:19','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(61,8,6,TO_DATE('10:08:30','HH24:MI:SS'),TO_DATE('18:02:56','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(62,8,5,TO_DATE('10:24:30','HH24:MI:SS'),TO_DATE('15:24:30','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(63,8,8,TO_DATE('09:11:14','HH24:MI:SS'),TO_DATE('17:11:12','HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(64,8,9,TO_DATE('10:03:24','HH24:MI:SS'),TO_DATE('16:07:01','HH24:MI:SS'));

INSERT INTO ABSENSI VALUES(9,'ENH30',TO_DATE('30/05/2021','DD/MM/YYYY'));
INSERT INTO ABSENSI VALUES(10,'DAJ31',TO_DATE('31/05/2021','DD/MM/YYYY'));


INSERT INTO TRANSAKSI VALUES(1,'PM2021051800001',1,1,'NICHOLAS TJANDRA','OVO',630000,87000,543000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
-- id transaksi, id menu , jumlah menu yang dipesan 
INSERT INTO D_TRANSAKSI VALUES(1,1,4); -- 
INSERT INTO D_TRANSAKSI VALUES(1,5,5);
INSERT INTO D_TRANSAKSI VALUES(1,2,10);
INSERT INTO D_TRANSAKSI VALUES(1,4,5);

INSERT INTO TRANSAKSI VALUES(2,'PM2021051800002',1,3,'NICHOLAS TJANDRA','OVO',300000,51000,249000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(2,1,4);
INSERT INTO D_TRANSAKSI VALUES(2,5,5);
INSERT INTO D_TRANSAKSI VALUES(2,2,10);
INSERT INTO D_TRANSAKSI VALUES(2,4,5);

INSERT INTO TRANSAKSI VALUES(3,'PM2021051800003',1,4,'NICHOLAS TJANDRA','GOPAY',237800,21800,216000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(3,3,2);--70k, 7k
INSERT INTO D_TRANSAKSI VALUES(3,4,2);-- 74000,14800
INSERT INTO D_TRANSAKSI VALUES(3,9,2);
INSERT INTO D_TRANSAKSI VALUES(3,10,6);
INSERT INTO D_TRANSAKSI VALUES(3,6,4);

INSERT INTO TRANSAKSI VALUES(4,'PM2021051800004',1,9,'NICHOLAS TJANDRA','SHOPEEPAY',196000,3500,192500,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(4,1,1);
INSERT INTO D_TRANSAKSI VALUES(4,3,1);
INSERT INTO D_TRANSAKSI VALUES(4,5,2);
INSERT INTO D_TRANSAKSI VALUES(4,7,4);
INSERT INTO D_TRANSAKSI VALUES(4,11,2);

INSERT INTO TRANSAKSI VALUES(5,'PM2021051800005',1,10,'PATRICK KUSANAGI','CASH',82000,0,82000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(5,1,1);
INSERT INTO D_TRANSAKSI VALUES(5,6,1);
INSERT INTO D_TRANSAKSI VALUES(5,8,1);
INSERT INTO D_TRANSAKSI VALUES(5,11,1);

INSERT INTO TRANSAKSI VALUES(6,'PM2021051800006',1,2,'PATRICK KUSANAGI','GOPAY',120000,8500,111500,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(6,2,1);
INSERT INTO D_TRANSAKSI VALUES(6,3,1);
INSERT INTO D_TRANSAKSI VALUES(6,5,1);
INSERT INTO D_TRANSAKSI VALUES(6,6,1);
INSERT INTO D_TRANSAKSI VALUES(6,7,1);
INSERT INTO D_TRANSAKSI VALUES(6,8,1);
INSERT INTO D_TRANSAKSI VALUES(6,10,3);


INSERT INTO TRANSAKSI VALUES(7,'PM2021051800007',1,5,'PATRICK KUSANAGI','OVO',69000,0,69000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(7,6,3);
INSERT INTO D_TRANSAKSI VALUES(7,7,2);
INSERT INTO D_TRANSAKSI VALUES(7,8,1);
INSERT INTO D_TRANSAKSI VALUES(7,9,1);


INSERT INTO TRANSAKSI VALUES(8,'PM2021051800008',1,6,'PATRICK KUSANAGI','CASH',81000,0,81000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(8,12,1);
INSERT INTO D_TRANSAKSI VALUES(8,13,1);
INSERT INTO D_TRANSAKSI VALUES(8,16,1);


INSERT INTO TRANSAKSI VALUES(9,'PM2021051800009',1,7,'PATRICK KUSANAGI','OVO',219000,0,219000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(9,15,2);
INSERT INTO D_TRANSAKSI VALUES(9,16,3);
INSERT INTO D_TRANSAKSI VALUES(9,6,3);

INSERT INTO TRANSAKSI VALUES(10,'PM2021051800010',1,8,'PATRICK KUSANAGI','CASH',90000,0,90000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(10,1,2);
INSERT INTO D_TRANSAKSI VALUES(10,6,2);
INSERT INTO D_TRANSAKSI VALUES(10,7,1);

INSERT INTO RESERVATION VALUES(1,2,1,TO_DATE('01/06/2021','DD/MM/YYYY'),TO_DATE('12:00:00','HH24:MI:SS'),TO_DATE('14:00:00','HH24:MI:SS'));
INSERT INTO RESERVATION VALUES(2,1,2,TO_DATE('01/06/2021','DD/MM/YYYY'),TO_DATE('18:30:00','HH24:MI:SS'),TO_DATE('20:30:00','HH24:MI:SS'));
INSERT INTO RESERVATION VALUES(3,5,3,TO_DATE('01/06/2021','DD/MM/YYYY'),TO_DATE('13:15:00','HH24:MI:SS'),TO_DATE('15:15:00','HH24:MI:SS'));
INSERT INTO RESERVATION VALUES(4,3,1,TO_DATE('02/06/2021','DD/MM/YYYY'),TO_DATE('11:00:00','HH24:MI:SS'),TO_DATE('13:00:00','HH24:MI:SS'));
INSERT INTO RESERVATION VALUES(5,4,5,TO_DATE('02/06/2021','DD/MM/YYYY'),TO_DATE('17:00:00','HH24:MI:SS'),TO_DATE('19:00:00','HH24:MI:SS'));
INSERT INTO RESERVATION VALUES(6,7,9,TO_DATE('02/06/2021','DD/MM/YYYY'),TO_DATE('16:45:00','HH24:MI:SS'),TO_DATE('18:45:00','HH24:MI:SS'));
INSERT INTO RESERVATION VALUES(7,8,10,TO_DATE('03/06/2021','DD/MM/YYYY'),TO_DATE('19:45:00','HH24:MI:SS'),TO_DATE('21:45:00','HH24:MI:SS'));
INSERT INTO RESERVATION VALUES(8,6,7,TO_DATE('03/06/2021','DD/MM/YYYY'),TO_DATE('18:00:00','HH24:MI:SS'),TO_DATE('20:30:00','HH24:MI:SS'));

CREATE OR REPLACE FUNCTION CREATE_NOTA
RETURN VARCHAR2
IS
    CTR NUMBER;
    FLAG BOOLEAN;
    TEMP NUMBER;
BEGIN
    FLAG := TRUE;
    CTR := 1;
	
    SELECT NVL(COUNT(*),0) INTO TEMP 
    FROM TRANSAKSI
    WHERE NOMOR_NOTA LIKE 'PM' || TO_CHAR(SYSDATE,'YYYYMMDD') || '%';
    CTR := CTR + TEMP;
RETURN 'PM' || TO_CHAR(SYSDATE,'YYYYMMDD') || LPAD(CTR,5,'0');
END;
/
SHOW ERR;

CREATE OR REPLACE TRIGGER TRIGGER_TRANSAKSI
BEFORE INSERT ON TRANSAKSI 
FOR EACH ROW 
DECLARE
	TMP NUMBER;
	USER VARCHAR2(50);
	
BEGIN 
	USER := '-1';
	SELECT COUNT(ID) INTO TMP FROM TRANSAKSI;
	  
    :NEW.ID := TMP + 1;
END;
/
SHOW ERR;

commit;

