CREATE TABLE "public.User" (
	"id" serial NOT NULL,
	"Name" varchar(40) NOT NULL,
	"Pin" varchar(30) NOT NULL,
	CONSTRAINT "User_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "public.Order" (
	"id" serial NOT NULL,
	"user_ID" integer NOT NULL,
	"balance" integer NOT NULL,
	CONSTRAINT "Order_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "public.Operations" (
	"id" serial NOT NULL,
	"order_ID" integer NOT NULL,
	"name" varchar(50) NOT NULL,
	"amount" integer NOT NULL,
	CONSTRAINT "Operations_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);




ALTER TABLE "Order" ADD CONSTRAINT "Order_fk0" FOREIGN KEY ("user_ID") REFERENCES "User"("id");

ALTER TABLE "Operations" ADD CONSTRAINT "Operations_fk0" FOREIGN KEY ("order_ID") REFERENCES "Order"("id");




