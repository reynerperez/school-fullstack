--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-06-03 02:06:37

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4871 (class 1262 OID 16490)
-- Name: school; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE school WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Mexico.1252';


ALTER DATABASE school OWNER TO postgres;

\connect school

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4872 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 16510)
-- Name: grades; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.grades (
    id integer NOT NULL,
    name character varying(250) NOT NULL,
    professor_id integer NOT NULL
);


ALTER TABLE public.grades OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16509)
-- Name: grades_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.grades_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.grades_id_seq OWNER TO postgres;

--
-- TOC entry 4873 (class 0 OID 0)
-- Dependencies: 219
-- Name: grades_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.grades_id_seq OWNED BY public.grades.id;


--
-- TOC entry 218 (class 1259 OID 16501)
-- Name: professors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.professors (
    id integer NOT NULL,
    name character varying(250) NOT NULL,
    last_name character varying(250) NOT NULL,
    gender character(1) NOT NULL
);


ALTER TABLE public.professors OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16500)
-- Name: professors_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.professors_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.professors_id_seq OWNER TO postgres;

--
-- TOC entry 4874 (class 0 OID 0)
-- Dependencies: 217
-- Name: professors_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.professors_id_seq OWNED BY public.professors.id;


--
-- TOC entry 222 (class 1259 OID 16517)
-- Name: student_grade; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student_grade (
    id integer NOT NULL,
    student_id integer NOT NULL,
    grade_id integer NOT NULL,
    section character varying(250) NOT NULL
);


ALTER TABLE public.student_grade OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16516)
-- Name: student_grade_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.student_grade_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.student_grade_id_seq OWNER TO postgres;

--
-- TOC entry 4875 (class 0 OID 0)
-- Dependencies: 221
-- Name: student_grade_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.student_grade_id_seq OWNED BY public.student_grade.id;


--
-- TOC entry 216 (class 1259 OID 16492)
-- Name: students; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.students (
    id integer NOT NULL,
    name character varying(250) NOT NULL,
    last_name character varying(250) NOT NULL,
    gender character(1) NOT NULL,
    birth_date date NOT NULL
);


ALTER TABLE public.students OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16491)
-- Name: students_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.students_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.students_id_seq OWNER TO postgres;

--
-- TOC entry 4876 (class 0 OID 0)
-- Dependencies: 215
-- Name: students_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.students_id_seq OWNED BY public.students.id;


--
-- TOC entry 4705 (class 2604 OID 16513)
-- Name: grades id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.grades ALTER COLUMN id SET DEFAULT nextval('public.grades_id_seq'::regclass);


--
-- TOC entry 4704 (class 2604 OID 16504)
-- Name: professors id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professors ALTER COLUMN id SET DEFAULT nextval('public.professors_id_seq'::regclass);


--
-- TOC entry 4706 (class 2604 OID 16520)
-- Name: student_grade id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_grade ALTER COLUMN id SET DEFAULT nextval('public.student_grade_id_seq'::regclass);


--
-- TOC entry 4703 (class 2604 OID 16495)
-- Name: students id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.students ALTER COLUMN id SET DEFAULT nextval('public.students_id_seq'::regclass);


--
-- TOC entry 4863 (class 0 OID 16510)
-- Dependencies: 220
-- Data for Name: grades; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.grades (id, name, professor_id) FROM stdin;
\.


--
-- TOC entry 4861 (class 0 OID 16501)
-- Dependencies: 218
-- Data for Name: professors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.professors (id, name, last_name, gender) FROM stdin;
\.


--
-- TOC entry 4865 (class 0 OID 16517)
-- Dependencies: 222
-- Data for Name: student_grade; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student_grade (id, student_id, grade_id, section) FROM stdin;
\.


--
-- TOC entry 4859 (class 0 OID 16492)
-- Dependencies: 216
-- Data for Name: students; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.students (id, name, last_name, gender, birth_date) FROM stdin;
62	123	123	m	2024-06-03
\.


--
-- TOC entry 4877 (class 0 OID 0)
-- Dependencies: 219
-- Name: grades_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.grades_id_seq', 1, false);


--
-- TOC entry 4878 (class 0 OID 0)
-- Dependencies: 217
-- Name: professors_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.professors_id_seq', 1, false);


--
-- TOC entry 4879 (class 0 OID 0)
-- Dependencies: 221
-- Name: student_grade_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.student_grade_id_seq', 1, false);


--
-- TOC entry 4880 (class 0 OID 0)
-- Dependencies: 215
-- Name: students_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.students_id_seq', 62, true);


--
-- TOC entry 4712 (class 2606 OID 16515)
-- Name: grades grades_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.grades
    ADD CONSTRAINT grades_pk PRIMARY KEY (id);


--
-- TOC entry 4710 (class 2606 OID 16508)
-- Name: professors professors_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professors
    ADD CONSTRAINT professors_pk PRIMARY KEY (id);


--
-- TOC entry 4714 (class 2606 OID 16522)
-- Name: student_grade student_grade_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_grade
    ADD CONSTRAINT student_grade_pk PRIMARY KEY (id);


--
-- TOC entry 4708 (class 2606 OID 16499)
-- Name: students students_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_pk PRIMARY KEY (id);


-- Completed on 2024-06-03 02:06:37

--
-- PostgreSQL database dump complete
--

