DROP TABLE JENIS_MENU CASCADE CONSTRAINT PURGE;
DROP TABLE MENU CASCADE CONSTRAINT PURGE;
DROP TABLE JABATAN CASCADE CONSTRAINT PURGE;
DROP TABLE KARYAWAN CASCADE CONSTRAINT PURGE;
DROP TABLE ABSENSI CASCADE CONSTRAINT PURGE;
DROP TABLE D_ABSENSI CASCADE CONSTRAINT PURGE;
DROP TABLE IZIN_ABSENSI CASCADE CONSTRAINT PURGE;
DROP TABLE PENGGAJIAN CASCADE CONSTRAINT PURGE;
DROP TABLE D_PENGGAJIAN CASCADE CONSTRAINT PURGE;
DROP TABLE PELANGGAN CASCADE CONSTRAINT PURGE;
DROP TABLE VOUCHER CASCADE CONSTRAINT PURGE;
DROP TABLE MEJA CASCADE CONSTRAINT PURGE;
DROP TABLE WAITING_LIST CASCADE CONSTRAINT PURGE;
DROP TABLE TRANSAKSI CASCADE CONSTRAINT PURGE;
DROP TABLE D_TRANSAKSI CASCADE CONSTRAINT PURGE;


create table jenis_menu ( --sudah
	ID NUMBER PRIMARY KEY,
	KODE_JENIS VARCHAR2(5) NOT NULL,
	NAMA_JENIS VARCHAR(50) NOT NULL
);

create table menu( --sudah
	ID NUMBER PRIMARY KEY,
	ID_JENIS_MENU NUMBER REFERENCES JENIS_MENU(ID),
	KODE_MENU VARCHAR2(5) NOT NULL,
	NAMA_MENU VARCHAR2(55) NOT NULL,
	STATUS NUMBER NOT NULL CHECK(STATUS = 0 OR STATUS = 1),
	HARGA NUMBER NOT NULL,
	DISKON NUMBER NOT NULL,
	HARGA_AKHIR NUMBER NOT NULL
);

CREATE TABLE JABATAN(	--sudah
	ID NUMBER PRIMARY KEY,
	NAMA_JABATAN VARCHAR2(50) NOT NULL,
	GAJI_POKOK NUMBER NOT NULL
);

CREATE TABLE KARYAWAN( --sudah
	ID NUMBER PRIMARY KEY,
	ID_JABATAN NUMBER REFERENCES JABATAN(ID),
	USERNAME VARCHAR2(12) UNIQUE,
	PASS VARCHAR2(50) NOT NULL,
	NAMA_KARYAWAN VARCHAR2(50) NOT NULL,
	TGL_DAFTAR DATE NOT NULL
);

CREATE TABLE ABSENSI( --sudah
	ID NUMBER PRIMARY KEY, 
	KODE_ABSEN VARCHAR2(5) NOT NULL, 
	TGL_ABSEN DATE NOT NULL
);

CREATE TABLE D_ABSENSI( --sudah
	ID NUMBER PRIMARY KEY,
	ID_ABSEN REFERENCES ABSENSI(ID),
	ID_KARYAWAN NUMBER REFERENCES KARYAWAN(ID),
	JAM_MASUK VARCHAR2(50) NOT NULL,
	JAM_PULANG VARCHAR2(50) NOT NULL
);

CREATE TABLE IZIN_ABSENSI( -- ini table untuk absensi karyawan ketika izin tidak masuk atau absen
	ID NUMBER PRIMARY KEY,
	ID_KARYAWAN NUMBER REFERENCES KARYAWAN(ID),
	JENIS_IZIN_ABSENSI VARCHAR2(4) NOT NULL CHECK(JENIS_IZIN_ABSENSI NOT IN('IZIN', 'CUTI')),
	TGL_MULAI DATE NOT NULL,
	TGL_AKHIR DATE NOT NULL
);

CREATE TABLE PENGGAJIAN( --sudah 
	NOMOR_SLIP VARCHAR2(15) PRIMARY KEY,
	ID_KARYAWAN NUMBER REFERENCES KARYAWAN(ID),
	TOTAL_GAJI_BERSIH NUMBER NOT NULL,
	TGL_WAKTU_PENGGAJIAN DATE NOT NULL
);

CREATE TABLE D_PENGGAJIAN(
	NOMOR_SLIP VARCHAR2(15) REFERENCES PENGGAJIAN(NOMOR_SLIP),
	NAMA_KARYAWAN VARCHAR2(50) NOT NULL,
	GAJI_POKOK NUMBER NOT NULL,
	TOTAL_TRANSPORT NUMBER NOT NULL,
	BONUS NUMBER NOT NULL, -- bonus berdasarkan absen
	TOTAL_MAKAN NUMBER NOT NULL
);

CREATE TABLE PELANGGAN( 
	ID NUMBER PRIMARY KEY,
	NAMA_PELANGGAN VARCHAR2(50) NOT NULL,
	ALAMAT VARCHAR2(50) NOT NULL,
	NO_TELP VARCHAR(12) UNIQUE
);

CREATE TABLE VOUCHER(
	ID NUMBER PRIMARY KEY,
	NAMA VARCHAR2(50) NOT NULL,
	NILAI NUMBER NOT NULL
);

CREATE TABLE MEJA(
	ID NUMBER PRIMARY KEY,
	TERSEDIA CHAR NOT NULL CHECK(TERSEDIA = 'N' OR TERSEDIA = 'Y')
);

--Perkiraan keluar adalah waktu perkiraan pelanggan makan menggunakan meja tersebut, apabila waktu yang ditentukan sudah lewat maka meja akan dapat digunakan oleh pelanggan lain
CREATE TABLE D_MEJA(
	ID NUMBER PRIMARY KEY, 
	ID_MEJA REFERENCES MEJA(ID),
	WAKTU_PESAN TIMESTAMP NOT NULL,
	PERKIRAAN_KELUAR TIMESTAMP NOT NULL
);

CREATE TABLE WAITING_LIST(
	ID NUMBER PRIMARY KEY,
	ID_PELANGGAN NUMBER REFERENCES PELANGGAN(ID),
	ID_MEJA NUMBER REFERENCES MEJA(ID),
	TGL_WAKTU_PEMESANAN DATE NOT NULL
);

CREATE TABLE TRANSAKSI(
	ID NUMBER PRIMARY KEY, 
	NOMOR_NOTA VARCHAR2(15) NOT NULL,
	ID_PELANGGAN NUMBER REFERENCES PELANGGAN(ID),
	NO_MEJA NUMBER REFERENCES MEJA(ID),
	NAMA_KASIR VARCHAR2(50) NOT NULL,
	METODE_PEMBAYARAN VARCHAR2(50) NOT NULL,
	TOTAL_PEMBELIAN NUMBER NOT NULL,
	POTONGAN_PEMBELIAN NUMBER NOT NULL,
	TOTAL_AKHIR NUMBER NOT NULL,
	TGL_PEMBELIAN DATE NOT NULL
);

CREATE TABLE D_TRANSAKSI(
	ID_TRANSAKSI NUMBER REFERENCES TRANSAKSI(ID),
	ID_MENU NUMBER REFERENCES MENU(ID),
	JUMLAH_MENU NUMBER NOT NULL,
	HARGA_MENU NUMBER NOT NULL,
	DISKON_MENU NUMBER NOT NULL,
	TOTAL NUMBER NOT NULL
);

INSERT INTO JENIS_MENU VALUES(1,'SE001','SEAFOOD');
INSERT INTO JENIS_MENU VALUES(2,'AY001','AYAM');
INSERT INTO JENIS_MENU VALUES(3,'SA001','SAYUR');
INSERT INTO JENIS_MENU VALUES(4,'MI001','MINUMAN');
INSERT INTO JENIS_MENU VALUES(5,'DE001','DESSERT');
INSERT INTO JENIS_MENU VALUES(6,'NA001','NASI');

INSERT INTO MENU VALUES(1,1,'CG001','CUMI GORENG TEPUNG',1,35000,0,35000);
INSERT INTO MENU VALUES(2,1,'CG002','CUMI GORENG MENTEGA',1,20000,25,15000);
INSERT INTO MENU VALUES(3,2,'AB001','AYAM BAKAR',1,35000,10,31500);
INSERT INTO MENU VALUES(4,3,'CB001','CAH BABY KAILAN',1,37000,20,29600);
INSERT INTO MENU VALUES(5,3,'CK001','CAH KANGKUNG',0,21000,0,21000);
INSERT INTO MENU VALUES(6,4,'TT001','TEH TAWAR',1,6000,0,6000);
INSERT INTO MENU VALUES(7,4,'TM001','TEH MANIS',1,8000,0,8000);
INSERT INTO MENU VALUES(8,5,'EC001','ES CAMPUR',1,15000,0,15000);
INSERT INTO MENU VALUES(9,5,'ED001','ES DAWET',1,20000,0,20000);
INSERT INTO MENU VALUES(10,6,'NP001','NASI PUTIH',1,5000,0,5000);
INSERT INTO MENU VALUES(11,6,'NG001','NASI GORENG HONGKONG',1,26000,0,26000);

-- MANAJER := Pemilik jabatan tertinggi di sistem restoran ini
-- KOKI := Tugas nya adalah menyiapkan pesanan dari pelayan untuk ditujukan kepada pelanggan
-- PELAYAN := Tugas nya adalah menyampaikan data permintaan pelanggan kepada koki
-- KASIR := Tugas nya adalah mencatat seluruh total biaya dari pesanan milik pelanggan
-- RESEPSIONIS := Tugas nya adalah memasukkan data Waiting List dari pelanggan
-- Gaji := gaji yang diberikan adalah gaji per jamnya
INSERT INTO JABATAN VALUES(1,'MANAJER',40000);
INSERT INTO JABATAN VALUES(2,'KOKI',35000);
INSERT INTO JABATAN VALUES(3,'PELAYAN',30000);
INSERT INTO JABATAN VALUES(4,'KASIR',30000);

INSERT INTO KARYAWAN VALUES(1,4,'PATKUS123','PatricKus','PATRICK KUSANAGI',TO_DATE('12/03/2018','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(2,3,'ANDREHEBAT','AndrianSug','ANDRIAN SUGIANTO',TO_DATE('12/03/2018','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(3,4,'LUKKY23','LukkyHar','LUKKY HARIYANTO',TO_DATE('24/12/2020','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(4,2,'STEVEN57','StevenLim','STEVEN LIEM',TO_DATE('24/01/2021','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(5,1,'ERICKN123','ErickN','ERICK NATHANAEL',TO_DATE('08/03/2021','DD/MM/YYYY'));
INSERT INTO KARYAWAN VALUES(6,4,'TEJE11','Teje123','NICHOLAS TJANDRA',TO_DATE('10/01/2021','DD/MM/YYYY'));


INSERT INTO PELANGGAN VALUES(1,'BUDI DOREMI','JL. BUNTU 4 NO 7','087853111900');
INSERT INTO PELANGGAN VALUES(2,'MICHAEL ANGELO', 'JL. RAYA 6 NO 10','08972018528');
INSERT INTO PELANGGAN VALUES(3,'BIMA SAPUTRA','JL. NINJA 2 NO 17','08977205819');

INSERT INTO ABSENSI VALUES(1,'WMP22',TO_DATE('22/05/2021','DD/MM/YYYY'));
INSERT INTO ABSENSI VALUES(2,'HRM23',TO_DATE('23/05/2021','DD/MM/YYYY'));
INSERT INTO ABSENSI VALUES(3,'ASQ24',TO_DATE('24/05/2021','DD/MM/YYYY'));


INSERT INTO D_ABSENSI VALUES(1,1,1,TO_CHAR(TO_DATE('10:24:30','HH24:MI:SS'),'HH24:MI:SS'),TO_CHAR(TO_DATE('15:24:30','HH24:MI:SS'),'HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(2,1,2,TO_CHAR(TO_DATE('09:11:14','HH24:MI:SS'),'HH24:MI:SS'),TO_CHAR(TO_DATE('17:11:12','HH24:MI:SS'),'HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(3,1,3,TO_CHAR(TO_DATE('10:03:24','HH24:MI:SS'),'HH24:MI:SS'),TO_CHAR(TO_DATE('16:07:01','HH24:MI:SS'),'HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(4,1,4,TO_CHAR(TO_DATE('10:01:01','HH24:MI:SS'),'HH24:MI:SS'),TO_CHAR(TO_DATE('17:10:19','HH24:MI:SS'),'HH24:MI:SS'));
INSERT INTO D_ABSENSI VALUES(5,1,5,TO_CHAR(TO_DATE('10:08:30','HH24:MI:SS'),'HH24:MI:SS'),TO_CHAR(TO_DATE('18:02:56','HH24:MI:SS'),'HH24:MI:SS'));



INSERT INTO TRANSAKSI VALUES(1,'PM2021051800001',NULL,1,'NICHOLAS TJANDRA','OVO',630000,87000,543000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(1,1,4,35000,0,140000);
INSERT INTO D_TRANSAKSI VALUES(1,5,5,21000,0,105000);
INSERT INTO D_TRANSAKSI VALUES(1,2,10,20000,50000,150000);
INSERT INTO D_TRANSAKSI VALUES(1,4,5,37000,37000,148000);

INSERT INTO TRANSAKSI VALUES(2,'PM2021051800002',NULL,3,'NICHOLAS TJANDRA','OVO',300000,51000,249000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(2,1,4,35000,0,140000);
INSERT INTO D_TRANSAKSI VALUES(2,5,5,21000,0,105000);
INSERT INTO D_TRANSAKSI VALUES(2,2,10,20000,50000,150000);
INSERT INTO D_TRANSAKSI VALUES(2,4,5,37000,37000,148000);

INSERT INTO TRANSAKSI VALUES(3,'PM2021051800003',NULL,4,'NICHOLAS TJANDRA','GOPAY',200000,25000,175000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO D_TRANSAKSI VALUES(3,6,)

INSERT INTO TRANSAKSI VALUES(4,'PM2021051800004',NULL,9,'NICHOLAS TJANDRA','SHOPEEPAY',90000,10000,80000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO TRANSAKSI VALUES(5,'PM2021051800005',NULL,10,'PATRICK KUSANAGI','CASH',1250000,120000,1130000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO TRANSAKSI VALUES(6,'PM2021051800006',NULL,2,'PATRICK KUSANAGI','GOPAY',781000,32000,749000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO TRANSAKSI VALUES(7,'PM2021051800007',NULL,5,'PATRICK KUSANAGI','OVO',180000,25000,155000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO TRANSAKSI VALUES(8,'PM2021051800008',NULL,6,'PATRICK KUSANAGI','CASH',247000,47000,200000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO TRANSAKSI VALUES(9,'PM2021051800009',NULL,7,'PATRICK KUSANAGI','OVO',670000,70000,600000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));
INSERT INTO TRANSAKSI VALUES(10,'PM2021051800010',NULL,8,'PATRICK KUSANAGI','CASH',230000,12000,218000,TO_CHAR(TO_DATE('2021 - 05 - 18','YYYY - MM - DD')));

INSERT INTO MEJA VALUES(1,'Y');
INSERT INTO MEJA VALUES(2,'Y');
INSERT INTO MEJA VALUES(3,'Y');
INSERT INTO MEJA VALUES(4,'Y');
INSERT INTO MEJA VALUES(5,'Y');
INSERT INTO MEJA VALUES(6,'Y');
INSERT INTO MEJA VALUES(7,'Y');
INSERT INTO MEJA VALUES(8,'Y');
INSERT INTO MEJA VALUES(9,'Y');
INSERT INTO MEJA VALUES(10,'Y');

CREATE OR REPLACE TRIGGER TRIGGER_KARYAWAN
BEFORE INSERT ON KARYAWAN 
FOR EACH ROW 
DECLARE
	TMP NUMBER;
	USER VARCHAR2(50);
	X_USER EXCEPTION;
BEGIN 
	USER := '-1';
	SELECT COUNT(ID) INTO TMP FROM KARYAWAN;
	SELECT USERNAME INTO USER FROM KARYAWAN WHERE USERNAME = :NEW.USERNAME;
	IF USER = '-1' THEN RAISE X_USER;
	END IF;
	  
    :NEW.ID := TMP + 1;
    :NEW.TGL_DAFTAR := SYSDATE;
	
	EXCEPTION 
		WHEN X_USER THEN RAISE_APPLICATION_ERROR(-20002,'Username tidak boleh sama');
END;
/
SHOW ERR;

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

commit;
