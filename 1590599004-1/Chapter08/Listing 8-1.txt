create procedure sp_Trans_Test
   @newcustid nchar(5),
   @newcompname nvarchar(40), 
   @oldcustid nchar(5)
as
   declare @inserr int
   declare @delerr int
   declare @maxerr int

   set @maxerr = 0

   begin transaction

   -- Add a customer
   insert into customers (customerid, companyname)
   values(@newcustid, @newcompname)

   -- Save error number returned from Insert statement
   set @inserr = @@error
   if @inserr > @maxerr
      set @maxerr = @inserr

   -- Delete a customer
   delete from customers
   where customerid = @oldcustid

   -- Save error number returned from Delete statement
   set @delerr = @@error
   if @delerr > @maxerr
      set @maxerr = @delerr

   -- If an error occurred, roll back
   if @maxerr <> 0
      begin
         rollback
         print 'Transaction rolled back'
      end
   else
      begin
         commit
         print 'Transaction committed'
      end

   print 'INSERT error number:' + cast(@inserr as nvarchar(8))
   print 'DELETE error number:' + cast(@delerr as nvarchar(8))

   return @maxerr
