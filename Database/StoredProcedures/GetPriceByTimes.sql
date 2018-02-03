create or replace function GetPriceByTimes
(
	message out varchar2,
	times in integer,
	startTime in varchar2,
	schoolName in varchar2,
	studentIDNumber in varchar2
) return number as
    realStartTime varchar2(14);
	totalAmount number(8,2);
	n integer;
	checkSchoolName CFG_PRICING_STRATEGY.SCHOOL_NAME%TYPE;
	checkStudentIDNumber CFG_PRICING_STRATEGY.STUDENT_IDNUMBER%TYPE;
	cur SYS_REFCURSOR;
    cur_rec CFG_PRICING_STRATEGY%ROWTYPE;
	ref2 boolean;
	flag boolean;
	currentPriority integer;
begin
    if startTime is null then
        realStartTime:=to_char(current_date, 'yyyymmddhh24miss'); 
    else
        realStartTime:=startTime;
    end if;

	totalAmount:=0;

	select count(*) into n from CFG_PRICING_STRATEGY where SCHOOL_NAME=schoolName;
	if n>0 then
		checkSchoolName:=schoolName;
	else
		checkSchoolName:=null;
	end if;

	select count(*) into n from CFG_PRICING_STRATEGY where STUDENT_IDNUMBER=studentIDNumber;
	if n>0 then
		checkStudentIDNumber:=studentIDNumber;
	else
		checkStudentIDNumber:=null;
	end if;
	
    open cur for select *
		from CFG_PRICING_STRATEGY
		where
			(EFFECTIVE_DATE is null or EFFECTIVE_DATE<=substr(realStartTime, 1, 8)) and
			(EXPIRED_DATE is null or substr(realStartTime, 1, 8)<=EXPIRED_DATE) and
			(START_DATE is null or START_DATE<=substr(realStartTime, 1, 8)) and
			(END_DATE is null or substr(realStartTime, 1, 8)<=END_DATE) and
			(START_TIME is null or START_TIME<=substr(realStartTime, 9,6)) and
			(END_TIME is null or substr(realStartTime, 9,6)<=END_TIME) and
			(checkSchoolName is null or checkSchoolName=SCHOOL_NAME) and
			(checkStudentIDNumber is null or checkStudentIDNumber=STUDENT_IDNUMBER)
		order by PRIORITY;
	currentPriority:=null;
	message:='';
    loop
        fetch cur into cur_rec;
        exit when cur%NOTFOUND;
        
		if currentPriority=cur_rec.PRIORITY then continue;			--this priority already done
		end if;
		
		ref2:=true;
		flag:=true;
		if cur_rec.REFERENCE_METHOD1 is not null then
			case cur_rec.REFERENCE_METHOD1
				when '>' then flag:=totalAmount>cur_rec.REFERENCE_AMOUNT1;
				when '=' then flag:=totalAmount=cur_rec.REFERENCE_AMOUNT1;
				when '<' then flag:=totalAmount<cur_rec.REFERENCE_AMOUNT1;
				when '>=' then flag:=totalAmount>=cur_rec.REFERENCE_AMOUNT1;
				when '<=' then flag:=totalAmount<=cur_rec.REFERENCE_AMOUNT1;
				when '<>' then flag:=totalAmount<>cur_rec.REFERENCE_AMOUNT1;
				when '!=' then flag:=totalAmount!=cur_rec.REFERENCE_AMOUNT1;
				else flag:=true;
			end case;
			if cur_rec.REFERENCE_METHOD2 is not null and cur_rec.REFERENCE_RELATION is not null then
				case cur_rec.REFERENCE_METHOD2
					when '>' then ref2:=totalAmount>cur_rec.REFERENCE_AMOUNT2;
					when '=' then ref2:=totalAmount=cur_rec.REFERENCE_AMOUNT2;
					when '<' then ref2:=totalAmount<cur_rec.REFERENCE_AMOUNT2;
					when '>=' then ref2:=totalAmount>=cur_rec.REFERENCE_AMOUNT2;
					when '<=' then ref2:=totalAmount<=cur_rec.REFERENCE_AMOUNT2;
					when '<>' then ref2:=totalAmount<>cur_rec.REFERENCE_AMOUNT2;
					when '!=' then ref2:=totalAmount!=cur_rec.REFERENCE_AMOUNT2;
					else ref2:=true;
				end case;
				if cur_rec.REFERENCE_RELATION='||' then flag:=flag or ref2;
				else flag:=flag and ref2;
				end if;
			end if;
		end if;
		
		if flag then
			case cur_rec.ACTION
				when 'set' then totalAmount:=cur_rec.AMOUNT*times;
				when 'add' then totalAmount:=totalAmount+cur_rec.AMOUNT;
				when 'sub' then totalAmount:=totalAmount-cur_rec.AMOUNT;
				when 'mul' then totalAmount:=totalAmount*cur_rec.AMOUNT;
				when 'div' then totalAmount:=totalAmount/cur_rec.AMOUNT;
				else null;
			end case;
			currentPriority:=cur_rec.PRIORITY;
			if length(message)>0 then message:=message||';'||chr(13)||chr(10); end if;
			message:=message||'priority: '||cur_rec.PRIORITY||' '||cur_rec.ACTION||' '||cur_rec.AMOUNT
				||' effect on: '||case when cur_rec.EFFECTIVE_DATE is null then 'now' else cur_rec.EFFECTIVE_DATE end
				||' to '||case when cur_rec.EXPIRED_DATE is null then 'forever' else cur_rec.EXPIRED_DATE end||' '
				||case when cur_rec.REFERENCE_METHOD1 is null then '' else ' when '||cur_rec.REFERENCE_METHOD1||cur_rec.REFERENCE_AMOUNT1||case when cur_rec.REFERENCE_METHOD2 is null then '' else cur_rec.REFERENCE_RELATION||cur_rec.REFERENCE_METHOD2||cur_rec.REFERENCE_AMOUNT2 end end
				||' at '||case when cur_rec.START_TIME is null then '000000' else cur_rec.START_TIME end
				||'-'||case when cur_rec.END_TIME is null then '235959' else cur_rec.END_TIME end
				||' from '||case when cur_rec.START_DATE is null then 'now' else cur_rec.START_DATE end
				||' to '||case when cur_rec.START_DATE is null then 'forever' else cur_rec.START_DATE end
				||case when cur_rec.SCHOOL_NAME is null then '' else ' for school: '||cur_rec.SCHOOL_NAME end
				||case when cur_rec.STUDENT_IDNUMBER is null then '' else ' for student: '||cur_rec.STUDENT_IDNUMBER end;
		end if;
	end loop;
	return totalAmount;
end GetPriceByTimes;
/
