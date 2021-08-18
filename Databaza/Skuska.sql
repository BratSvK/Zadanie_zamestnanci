insert into Zamestnanec 
values(5,null,'Ing','Jano','Peterisnky','+421904344907','janpetertensky@gmail.com');


select * from Zamestnanec;

select * from Firma;


select zam.Meno, zam.Priezvisko from Zamestnanec zam
join Firma f on (f.id_veduci = zam.id_zamestnanec);


insert into Firma 
values(1,1,'GajdosStav');

insert into Divizia 
values(1,1,2,'PrvaDivizia');

insert into Projekt 
values(1,1,3,'View&Go');

insert into Oddelenie 
values(1,4,1,'Technik');

select p.Nazov from Projekt p 
join Divizia div on (div.id_divizia = p.id_divizia)
join Firma f on (f.id_firma = div.id_firma)
where f.id_firma = 1;


update zamestnanec 
set id_oddelenie = 1
where id_zamestnanec = 5;