using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.MsSqlCommands;

namespace DataAccess.MSSQL.Pos
{
	/// <summary>
	/// Controla la ejecucion de los procedimientos almacenados de la conexion Pos.
	/// </summary>
	public class Pos : IDisposable
	{
		#region Properties

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addbrand.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addbrand Addbrand = new DataAccess.MsSqlCommands.Pos.Addbrand();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addbudgetary.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addbudgetary Addbudgetary = new DataAccess.MsSqlCommands.Pos.Addbudgetary();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addclient.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addclient Addclient = new DataAccess.MsSqlCommands.Pos.Addclient();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Adddetailbudgetary.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Adddetailbudgetary Adddetailbudgetary = new DataAccess.MsSqlCommands.Pos.Adddetailbudgetary();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Adddetailexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Adddetailexpense Adddetailexpense = new DataAccess.MsSqlCommands.Pos.Adddetailexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Adddetailpurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Adddetailpurchase Adddetailpurchase = new DataAccess.MsSqlCommands.Pos.Adddetailpurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Adddetailsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Adddetailsale Adddetailsale = new DataAccess.MsSqlCommands.Pos.Adddetailsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addemployee.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addemployee Addemployee = new DataAccess.MsSqlCommands.Pos.Addemployee();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addexpense Addexpense = new DataAccess.MsSqlCommands.Pos.Addexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addfactory.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addfactory Addfactory = new DataAccess.MsSqlCommands.Pos.Addfactory();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addfiletopurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addfiletopurchase Addfiletopurchase = new DataAccess.MsSqlCommands.Pos.Addfiletopurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addfreight.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addfreight Addfreight = new DataAccess.MsSqlCommands.Pos.Addfreight();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addgroup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addgroup Addgroup = new DataAccess.MsSqlCommands.Pos.Addgroup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addimage.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addimage Addimage = new DataAccess.MsSqlCommands.Pos.Addimage();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addincome.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addincome Addincome = new DataAccess.MsSqlCommands.Pos.Addincome();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addlabel.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addlabel Addlabel = new DataAccess.MsSqlCommands.Pos.Addlabel();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addloan.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addloan Addloan = new DataAccess.MsSqlCommands.Pos.Addloan();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addlocation.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addlocation Addlocation = new DataAccess.MsSqlCommands.Pos.Addlocation();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addmaterial.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addmaterial Addmaterial = new DataAccess.MsSqlCommands.Pos.Addmaterial();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addmeasure.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addmeasure Addmeasure = new DataAccess.MsSqlCommands.Pos.Addmeasure();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addpayment.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addpayment Addpayment = new DataAccess.MsSqlCommands.Pos.Addpayment();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addpaymentsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addpaymentsale Addpaymentsale = new DataAccess.MsSqlCommands.Pos.Addpaymentsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addpm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addpm Addpm = new DataAccess.MsSqlCommands.Pos.Addpm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addprice.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addprice Addprice = new DataAccess.MsSqlCommands.Pos.Addprice();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addproduct.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addproduct Addproduct = new DataAccess.MsSqlCommands.Pos.Addproduct();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addpurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addpurchase Addpurchase = new DataAccess.MsSqlCommands.Pos.Addpurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addpurchasefather.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addpurchasefather Addpurchasefather = new DataAccess.MsSqlCommands.Pos.Addpurchasefather();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addsale Addsale = new DataAccess.MsSqlCommands.Pos.Addsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addsalefather.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addsalefather Addsalefather = new DataAccess.MsSqlCommands.Pos.Addsalefather();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addtelephonerecharge.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addtelephonerecharge Addtelephonerecharge = new DataAccess.MsSqlCommands.Pos.Addtelephonerecharge();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Addunioncostandsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Addunioncostandsale Addunioncostandsale = new DataAccess.MsSqlCommands.Pos.Addunioncostandsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Backupdb.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Backupdb Backupdb = new DataAccess.MsSqlCommands.Pos.Backupdb();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Backupgetinfo.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Backupgetinfo Backupgetinfo = new DataAccess.MsSqlCommands.Pos.Backupgetinfo();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Backupgetprocedures.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Backupgetprocedures Backupgetprocedures = new DataAccess.MsSqlCommands.Pos.Backupgetprocedures();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Backupgetproceduretext.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Backupgetproceduretext Backupgetproceduretext = new DataAccess.MsSqlCommands.Pos.Backupgetproceduretext();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Backupgettables.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Backupgettables Backupgettables = new DataAccess.MsSqlCommands.Pos.Backupgettables();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Backupgettabletext.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Backupgettabletext Backupgettabletext = new DataAccess.MsSqlCommands.Pos.Backupgettabletext();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Cancelsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Cancelsale Cancelsale = new DataAccess.MsSqlCommands.Pos.Cancelsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Checkbox.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Checkbox Checkbox = new DataAccess.MsSqlCommands.Pos.Checkbox();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Checkpmindetailpurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Checkpmindetailpurchase Checkpmindetailpurchase = new DataAccess.MsSqlCommands.Pos.Checkpmindetailpurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Closebox.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Closebox Closebox = new DataAccess.MsSqlCommands.Pos.Closebox();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Createbackup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Createbackup Createbackup = new DataAccess.MsSqlCommands.Pos.Createbackup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletebrand.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletebrand Deletebrand = new DataAccess.MsSqlCommands.Pos.Deletebrand();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deleteclient.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deleteclient Deleteclient = new DataAccess.MsSqlCommands.Pos.Deleteclient();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletedetailexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletedetailexpense Deletedetailexpense = new DataAccess.MsSqlCommands.Pos.Deletedetailexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deleteemployee.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deleteemployee Deleteemployee = new DataAccess.MsSqlCommands.Pos.Deleteemployee();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deleteexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deleteexpense Deleteexpense = new DataAccess.MsSqlCommands.Pos.Deleteexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletefreight.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletefreight Deletefreight = new DataAccess.MsSqlCommands.Pos.Deletefreight();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletegroup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletegroup Deletegroup = new DataAccess.MsSqlCommands.Pos.Deletegroup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deleteincome.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deleteincome Deleteincome = new DataAccess.MsSqlCommands.Pos.Deleteincome();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletelabel.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletelabel Deletelabel = new DataAccess.MsSqlCommands.Pos.Deletelabel();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deleteloan.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deleteloan Deleteloan = new DataAccess.MsSqlCommands.Pos.Deleteloan();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletelocation.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletelocation Deletelocation = new DataAccess.MsSqlCommands.Pos.Deletelocation();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletematerial.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletematerial Deletematerial = new DataAccess.MsSqlCommands.Pos.Deletematerial();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletemeasure.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletemeasure Deletemeasure = new DataAccess.MsSqlCommands.Pos.Deletemeasure();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletepayment.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletepayment Deletepayment = new DataAccess.MsSqlCommands.Pos.Deletepayment();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletepaymentsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletepaymentsale Deletepaymentsale = new DataAccess.MsSqlCommands.Pos.Deletepaymentsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletepm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletepm Deletepm = new DataAccess.MsSqlCommands.Pos.Deletepm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deleteproduct.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deleteproduct Deleteproduct = new DataAccess.MsSqlCommands.Pos.Deleteproduct();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Deletesale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Deletesale Deletesale = new DataAccess.MsSqlCommands.Pos.Deletesale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existbrand.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existbrand Existbrand = new DataAccess.MsSqlCommands.Pos.Existbrand();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existclient.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existclient Existclient = new DataAccess.MsSqlCommands.Pos.Existclient();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existemployee.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existemployee Existemployee = new DataAccess.MsSqlCommands.Pos.Existemployee();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existfreight.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existfreight Existfreight = new DataAccess.MsSqlCommands.Pos.Existfreight();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existgroup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existgroup Existgroup = new DataAccess.MsSqlCommands.Pos.Existgroup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existgroupbyprefix.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existgroupbyprefix Existgroupbyprefix = new DataAccess.MsSqlCommands.Pos.Existgroupbyprefix();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existlabel.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existlabel Existlabel = new DataAccess.MsSqlCommands.Pos.Existlabel();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existlocation.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existlocation Existlocation = new DataAccess.MsSqlCommands.Pos.Existlocation();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existmaterial.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existmaterial Existmaterial = new DataAccess.MsSqlCommands.Pos.Existmaterial();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existmeasure.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existmeasure Existmeasure = new DataAccess.MsSqlCommands.Pos.Existmeasure();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existpm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existpm Existpm = new DataAccess.MsSqlCommands.Pos.Existpm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Existproduct.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Existproduct Existproduct = new DataAccess.MsSqlCommands.Pos.Existproduct();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getbarcode.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getbarcode Getbarcode = new DataAccess.MsSqlCommands.Pos.Getbarcode();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getbrandurlsearch.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getbrandurlsearch Getbrandurlsearch = new DataAccess.MsSqlCommands.Pos.Getbrandurlsearch();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getclientname.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getclientname Getclientname = new DataAccess.MsSqlCommands.Pos.Getclientname();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getconcentratedreport.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getconcentratedreport Getconcentratedreport = new DataAccess.MsSqlCommands.Pos.Getconcentratedreport();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getconfiguration.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getconfiguration Getconfiguration = new DataAccess.MsSqlCommands.Pos.Getconfiguration();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getcurrentbox.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getcurrentbox Getcurrentbox = new DataAccess.MsSqlCommands.Pos.Getcurrentbox();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getexpense Getexpense = new DataAccess.MsSqlCommands.Pos.Getexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getidbynamegroup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getidbynamegroup Getidbynamegroup = new DataAccess.MsSqlCommands.Pos.Getidbynamegroup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getidbynamepm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getidbynamepm Getidbynamepm = new DataAccess.MsSqlCommands.Pos.Getidbynamepm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getidcompanybynamepm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getidcompanybynamepm Getidcompanybynamepm = new DataAccess.MsSqlCommands.Pos.Getidcompanybynamepm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getimagepm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getimagepm Getimagepm = new DataAccess.MsSqlCommands.Pos.Getimagepm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getincome.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getincome Getincome = new DataAccess.MsSqlCommands.Pos.Getincome();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getlocationbynamepm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getlocationbynamepm Getlocationbynamepm = new DataAccess.MsSqlCommands.Pos.Getlocationbynamepm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getnamebarcode.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getnamebarcode Getnamebarcode = new DataAccess.MsSqlCommands.Pos.Getnamebarcode();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getnameforrefillcancelsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getnameforrefillcancelsale Getnameforrefillcancelsale = new DataAccess.MsSqlCommands.Pos.Getnameforrefillcancelsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getnumberhourspurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getnumberhourspurchase Getnumberhourspurchase = new DataAccess.MsSqlCommands.Pos.Getnumberhourspurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getpricebarcode.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getpricebarcode Getpricebarcode = new DataAccess.MsSqlCommands.Pos.Getpricebarcode();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getpricepmfreight.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getpricepmfreight Getpricepmfreight = new DataAccess.MsSqlCommands.Pos.Getpricepmfreight();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getpurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getpurchase Getpurchase = new DataAccess.MsSqlCommands.Pos.Getpurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getpurchasecost.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getpurchasecost Getpurchasecost = new DataAccess.MsSqlCommands.Pos.Getpurchasecost();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getpurchasecostforsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getpurchasecostforsale Getpurchasecostforsale = new DataAccess.MsSqlCommands.Pos.Getpurchasecostforsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getsale Getsale = new DataAccess.MsSqlCommands.Pos.Getsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Getticketcompany.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Getticketcompany Getticketcompany = new DataAccess.MsSqlCommands.Pos.Getticketcompany();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Gettotaldebt.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Gettotaldebt Gettotaldebt = new DataAccess.MsSqlCommands.Pos.Gettotaldebt();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Lastbackup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Lastbackup Lastbackup = new DataAccess.MsSqlCommands.Pos.Lastbackup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listbrand.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listbrand Listbrand = new DataAccess.MsSqlCommands.Pos.Listbrand();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listcategoryexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listcategoryexpense Listcategoryexpense = new DataAccess.MsSqlCommands.Pos.Listcategoryexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listclient.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listclient Listclient = new DataAccess.MsSqlCommands.Pos.Listclient();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listcompany.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listcompany Listcompany = new DataAccess.MsSqlCommands.Pos.Listcompany();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listdestination.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listdestination Listdestination = new DataAccess.MsSqlCommands.Pos.Listdestination();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listdetailpurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listdetailpurchase Listdetailpurchase = new DataAccess.MsSqlCommands.Pos.Listdetailpurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listdetailsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listdetailsale Listdetailsale = new DataAccess.MsSqlCommands.Pos.Listdetailsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listemployee.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listemployee Listemployee = new DataAccess.MsSqlCommands.Pos.Listemployee();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listexpense Listexpense = new DataAccess.MsSqlCommands.Pos.Listexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listexpensedetail.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listexpensedetail Listexpensedetail = new DataAccess.MsSqlCommands.Pos.Listexpensedetail();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listfactory.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listfactory Listfactory = new DataAccess.MsSqlCommands.Pos.Listfactory();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listfreight.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listfreight Listfreight = new DataAccess.MsSqlCommands.Pos.Listfreight();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listgroup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listgroup Listgroup = new DataAccess.MsSqlCommands.Pos.Listgroup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listincome.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listincome Listincome = new DataAccess.MsSqlCommands.Pos.Listincome();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listlabel.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listlabel Listlabel = new DataAccess.MsSqlCommands.Pos.Listlabel();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listloan.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listloan Listloan = new DataAccess.MsSqlCommands.Pos.Listloan();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listlocation.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listlocation Listlocation = new DataAccess.MsSqlCommands.Pos.Listlocation();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listmaterial.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listmaterial Listmaterial = new DataAccess.MsSqlCommands.Pos.Listmaterial();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listmeasure.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listmeasure Listmeasure = new DataAccess.MsSqlCommands.Pos.Listmeasure();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpayment.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpayment Listpayment = new DataAccess.MsSqlCommands.Pos.Listpayment();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpaymentsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpaymentsale Listpaymentsale = new DataAccess.MsSqlCommands.Pos.Listpaymentsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpm Listpm = new DataAccess.MsSqlCommands.Pos.Listpm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpmbycode.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpmbycode Listpmbycode = new DataAccess.MsSqlCommands.Pos.Listpmbycode();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpmcombo.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpmcombo Listpmcombo = new DataAccess.MsSqlCommands.Pos.Listpmcombo();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpmstock.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpmstock Listpmstock = new DataAccess.MsSqlCommands.Pos.Listpmstock();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpmventas.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpmventas Listpmventas = new DataAccess.MsSqlCommands.Pos.Listpmventas();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listproduct.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listproduct Listproduct = new DataAccess.MsSqlCommands.Pos.Listproduct();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listprovider.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listprovider Listprovider = new DataAccess.MsSqlCommands.Pos.Listprovider();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpurchase Listpurchase = new DataAccess.MsSqlCommands.Pos.Listpurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listpurchase2.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listpurchase2 Listpurchase2 = new DataAccess.MsSqlCommands.Pos.Listpurchase2();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listsale Listsale = new DataAccess.MsSqlCommands.Pos.Listsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listsale2.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listsale2 Listsale2 = new DataAccess.MsSqlCommands.Pos.Listsale2();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Listtelephonerecharge.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Listtelephonerecharge Listtelephonerecharge = new DataAccess.MsSqlCommands.Pos.Listtelephonerecharge();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Openbox.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Openbox Openbox = new DataAccess.MsSqlCommands.Pos.Openbox();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Requirefreight.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Requirefreight Requirefreight = new DataAccess.MsSqlCommands.Pos.Requirefreight();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Setbarcode.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Setbarcode Setbarcode = new DataAccess.MsSqlCommands.Pos.Setbarcode();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Setconfiguration.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Setconfiguration Setconfiguration = new DataAccess.MsSqlCommands.Pos.Setconfiguration();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Smartpayment.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Smartpayment Smartpayment = new DataAccess.MsSqlCommands.Pos.Smartpayment();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Stockforsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Stockforsale Stockforsale = new DataAccess.MsSqlCommands.Pos.Stockforsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatebrand.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatebrand Updatebrand = new DataAccess.MsSqlCommands.Pos.Updatebrand();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updateclient.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updateclient Updateclient = new DataAccess.MsSqlCommands.Pos.Updateclient();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updateconfiguration.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updateconfiguration Updateconfiguration = new DataAccess.MsSqlCommands.Pos.Updateconfiguration();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatedetailexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatedetailexpense Updatedetailexpense = new DataAccess.MsSqlCommands.Pos.Updatedetailexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatedetailpurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatedetailpurchase Updatedetailpurchase = new DataAccess.MsSqlCommands.Pos.Updatedetailpurchase();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updateemployee.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updateemployee Updateemployee = new DataAccess.MsSqlCommands.Pos.Updateemployee();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updateexpense.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updateexpense Updateexpense = new DataAccess.MsSqlCommands.Pos.Updateexpense();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatefreight.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatefreight Updatefreight = new DataAccess.MsSqlCommands.Pos.Updatefreight();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updategroup.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updategroup Updategroup = new DataAccess.MsSqlCommands.Pos.Updategroup();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updateincome.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updateincome Updateincome = new DataAccess.MsSqlCommands.Pos.Updateincome();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatelabel.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatelabel Updatelabel = new DataAccess.MsSqlCommands.Pos.Updatelabel();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updateloan.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updateloan Updateloan = new DataAccess.MsSqlCommands.Pos.Updateloan();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatelocation.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatelocation Updatelocation = new DataAccess.MsSqlCommands.Pos.Updatelocation();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatematerial.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatematerial Updatematerial = new DataAccess.MsSqlCommands.Pos.Updatematerial();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatemeasure.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatemeasure Updatemeasure = new DataAccess.MsSqlCommands.Pos.Updatemeasure();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatepayment.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatepayment Updatepayment = new DataAccess.MsSqlCommands.Pos.Updatepayment();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatepaymentsale.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatepaymentsale Updatepaymentsale = new DataAccess.MsSqlCommands.Pos.Updatepaymentsale();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatepm.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatepm Updatepm = new DataAccess.MsSqlCommands.Pos.Updatepm();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updateproduct.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updateproduct Updateproduct = new DataAccess.MsSqlCommands.Pos.Updateproduct();

		/// <summary>
		/// Controla la ejecucion del procedimiento almacenado Updatepurchase.
		///</summary>
		public DataAccess.MsSqlCommands.Pos.Updatepurchase Updatepurchase = new DataAccess.MsSqlCommands.Pos.Updatepurchase();


		#endregion

		#region Methods

		public void Dispose()
		{
			if (this.Addbrand != null)
				this.Addbrand.Dispose();

			if (this.Addbudgetary != null)
				this.Addbudgetary.Dispose();

			if (this.Addclient != null)
				this.Addclient.Dispose();

			if (this.Adddetailbudgetary != null)
				this.Adddetailbudgetary.Dispose();

			if (this.Adddetailexpense != null)
				this.Adddetailexpense.Dispose();

			if (this.Adddetailpurchase != null)
				this.Adddetailpurchase.Dispose();

			if (this.Adddetailsale != null)
				this.Adddetailsale.Dispose();

			if (this.Addemployee != null)
				this.Addemployee.Dispose();

			if (this.Addexpense != null)
				this.Addexpense.Dispose();

			if (this.Addfactory != null)
				this.Addfactory.Dispose();

			if (this.Addfiletopurchase != null)
				this.Addfiletopurchase.Dispose();

			if (this.Addfreight != null)
				this.Addfreight.Dispose();

			if (this.Addgroup != null)
				this.Addgroup.Dispose();

			if (this.Addimage != null)
				this.Addimage.Dispose();

			if (this.Addincome != null)
				this.Addincome.Dispose();

			if (this.Addlabel != null)
				this.Addlabel.Dispose();

			if (this.Addloan != null)
				this.Addloan.Dispose();

			if (this.Addlocation != null)
				this.Addlocation.Dispose();

			if (this.Addmaterial != null)
				this.Addmaterial.Dispose();

			if (this.Addmeasure != null)
				this.Addmeasure.Dispose();

			if (this.Addpayment != null)
				this.Addpayment.Dispose();

			if (this.Addpaymentsale != null)
				this.Addpaymentsale.Dispose();

			if (this.Addpm != null)
				this.Addpm.Dispose();

			if (this.Addprice != null)
				this.Addprice.Dispose();

			if (this.Addproduct != null)
				this.Addproduct.Dispose();

			if (this.Addpurchase != null)
				this.Addpurchase.Dispose();

			if (this.Addpurchasefather != null)
				this.Addpurchasefather.Dispose();

			if (this.Addsale != null)
				this.Addsale.Dispose();

			if (this.Addsalefather != null)
				this.Addsalefather.Dispose();

			if (this.Addtelephonerecharge != null)
				this.Addtelephonerecharge.Dispose();

			if (this.Addunioncostandsale != null)
				this.Addunioncostandsale.Dispose();

			if (this.Backupdb != null)
				this.Backupdb.Dispose();

			if (this.Backupgetinfo != null)
				this.Backupgetinfo.Dispose();

			if (this.Backupgetprocedures != null)
				this.Backupgetprocedures.Dispose();

			if (this.Backupgetproceduretext != null)
				this.Backupgetproceduretext.Dispose();

			if (this.Backupgettables != null)
				this.Backupgettables.Dispose();

			if (this.Backupgettabletext != null)
				this.Backupgettabletext.Dispose();

			if (this.Cancelsale != null)
				this.Cancelsale.Dispose();

			if (this.Checkbox != null)
				this.Checkbox.Dispose();

			if (this.Checkpmindetailpurchase != null)
				this.Checkpmindetailpurchase.Dispose();

			if (this.Closebox != null)
				this.Closebox.Dispose();

			if (this.Createbackup != null)
				this.Createbackup.Dispose();

			if (this.Deletebrand != null)
				this.Deletebrand.Dispose();

			if (this.Deleteclient != null)
				this.Deleteclient.Dispose();

			if (this.Deletedetailexpense != null)
				this.Deletedetailexpense.Dispose();

			if (this.Deleteemployee != null)
				this.Deleteemployee.Dispose();

			if (this.Deleteexpense != null)
				this.Deleteexpense.Dispose();

			if (this.Deletefreight != null)
				this.Deletefreight.Dispose();

			if (this.Deletegroup != null)
				this.Deletegroup.Dispose();

			if (this.Deleteincome != null)
				this.Deleteincome.Dispose();

			if (this.Deletelabel != null)
				this.Deletelabel.Dispose();

			if (this.Deleteloan != null)
				this.Deleteloan.Dispose();

			if (this.Deletelocation != null)
				this.Deletelocation.Dispose();

			if (this.Deletematerial != null)
				this.Deletematerial.Dispose();

			if (this.Deletemeasure != null)
				this.Deletemeasure.Dispose();

			if (this.Deletepayment != null)
				this.Deletepayment.Dispose();

			if (this.Deletepaymentsale != null)
				this.Deletepaymentsale.Dispose();

			if (this.Deletepm != null)
				this.Deletepm.Dispose();

			if (this.Deleteproduct != null)
				this.Deleteproduct.Dispose();

			if (this.Deletesale != null)
				this.Deletesale.Dispose();

			if (this.Existbrand != null)
				this.Existbrand.Dispose();

			if (this.Existclient != null)
				this.Existclient.Dispose();

			if (this.Existemployee != null)
				this.Existemployee.Dispose();

			if (this.Existfreight != null)
				this.Existfreight.Dispose();

			if (this.Existgroup != null)
				this.Existgroup.Dispose();

			if (this.Existgroupbyprefix != null)
				this.Existgroupbyprefix.Dispose();

			if (this.Existlabel != null)
				this.Existlabel.Dispose();

			if (this.Existlocation != null)
				this.Existlocation.Dispose();

			if (this.Existmaterial != null)
				this.Existmaterial.Dispose();

			if (this.Existmeasure != null)
				this.Existmeasure.Dispose();

			if (this.Existpm != null)
				this.Existpm.Dispose();

			if (this.Existproduct != null)
				this.Existproduct.Dispose();

			if (this.Getbarcode != null)
				this.Getbarcode.Dispose();

			if (this.Getbrandurlsearch != null)
				this.Getbrandurlsearch.Dispose();

			if (this.Getclientname != null)
				this.Getclientname.Dispose();

			if (this.Getconcentratedreport != null)
				this.Getconcentratedreport.Dispose();

			if (this.Getconfiguration != null)
				this.Getconfiguration.Dispose();

			if (this.Getcurrentbox != null)
				this.Getcurrentbox.Dispose();

			if (this.Getexpense != null)
				this.Getexpense.Dispose();

			if (this.Getidbynamegroup != null)
				this.Getidbynamegroup.Dispose();

			if (this.Getidbynamepm != null)
				this.Getidbynamepm.Dispose();

			if (this.Getidcompanybynamepm != null)
				this.Getidcompanybynamepm.Dispose();

			if (this.Getimagepm != null)
				this.Getimagepm.Dispose();

			if (this.Getincome != null)
				this.Getincome.Dispose();

			if (this.Getlocationbynamepm != null)
				this.Getlocationbynamepm.Dispose();

			if (this.Getnamebarcode != null)
				this.Getnamebarcode.Dispose();

			if (this.Getnameforrefillcancelsale != null)
				this.Getnameforrefillcancelsale.Dispose();

			if (this.Getnumberhourspurchase != null)
				this.Getnumberhourspurchase.Dispose();

			if (this.Getpricebarcode != null)
				this.Getpricebarcode.Dispose();

			if (this.Getpricepmfreight != null)
				this.Getpricepmfreight.Dispose();

			if (this.Getpurchase != null)
				this.Getpurchase.Dispose();

			if (this.Getpurchasecost != null)
				this.Getpurchasecost.Dispose();

			if (this.Getpurchasecostforsale != null)
				this.Getpurchasecostforsale.Dispose();

			if (this.Getsale != null)
				this.Getsale.Dispose();

			if (this.Getticketcompany != null)
				this.Getticketcompany.Dispose();

			if (this.Gettotaldebt != null)
				this.Gettotaldebt.Dispose();

			if (this.Lastbackup != null)
				this.Lastbackup.Dispose();

			if (this.Listbrand != null)
				this.Listbrand.Dispose();

			if (this.Listcategoryexpense != null)
				this.Listcategoryexpense.Dispose();

			if (this.Listclient != null)
				this.Listclient.Dispose();

			if (this.Listcompany != null)
				this.Listcompany.Dispose();

			if (this.Listdestination != null)
				this.Listdestination.Dispose();

			if (this.Listdetailpurchase != null)
				this.Listdetailpurchase.Dispose();

			if (this.Listdetailsale != null)
				this.Listdetailsale.Dispose();

			if (this.Listemployee != null)
				this.Listemployee.Dispose();

			if (this.Listexpense != null)
				this.Listexpense.Dispose();

			if (this.Listexpensedetail != null)
				this.Listexpensedetail.Dispose();

			if (this.Listfactory != null)
				this.Listfactory.Dispose();

			if (this.Listfreight != null)
				this.Listfreight.Dispose();

			if (this.Listgroup != null)
				this.Listgroup.Dispose();

			if (this.Listincome != null)
				this.Listincome.Dispose();

			if (this.Listlabel != null)
				this.Listlabel.Dispose();

			if (this.Listloan != null)
				this.Listloan.Dispose();

			if (this.Listlocation != null)
				this.Listlocation.Dispose();

			if (this.Listmaterial != null)
				this.Listmaterial.Dispose();

			if (this.Listmeasure != null)
				this.Listmeasure.Dispose();

			if (this.Listpayment != null)
				this.Listpayment.Dispose();

			if (this.Listpaymentsale != null)
				this.Listpaymentsale.Dispose();

			if (this.Listpm != null)
				this.Listpm.Dispose();

			if (this.Listpmbycode != null)
				this.Listpmbycode.Dispose();

			if (this.Listpmcombo != null)
				this.Listpmcombo.Dispose();

			if (this.Listpmstock != null)
				this.Listpmstock.Dispose();

			if (this.Listpmventas != null)
				this.Listpmventas.Dispose();

			if (this.Listproduct != null)
				this.Listproduct.Dispose();

			if (this.Listprovider != null)
				this.Listprovider.Dispose();

			if (this.Listpurchase != null)
				this.Listpurchase.Dispose();

			if (this.Listpurchase2 != null)
				this.Listpurchase2.Dispose();

			if (this.Listsale != null)
				this.Listsale.Dispose();

			if (this.Listsale2 != null)
				this.Listsale2.Dispose();

			if (this.Listtelephonerecharge != null)
				this.Listtelephonerecharge.Dispose();

			if (this.Openbox != null)
				this.Openbox.Dispose();

			if (this.Requirefreight != null)
				this.Requirefreight.Dispose();

			if (this.Setbarcode != null)
				this.Setbarcode.Dispose();

			if (this.Setconfiguration != null)
				this.Setconfiguration.Dispose();

			if (this.Smartpayment != null)
				this.Smartpayment.Dispose();

			if (this.Stockforsale != null)
				this.Stockforsale.Dispose();

			if (this.Updatebrand != null)
				this.Updatebrand.Dispose();

			if (this.Updateclient != null)
				this.Updateclient.Dispose();

			if (this.Updateconfiguration != null)
				this.Updateconfiguration.Dispose();

			if (this.Updatedetailexpense != null)
				this.Updatedetailexpense.Dispose();

			if (this.Updatedetailpurchase != null)
				this.Updatedetailpurchase.Dispose();

			if (this.Updateemployee != null)
				this.Updateemployee.Dispose();

			if (this.Updateexpense != null)
				this.Updateexpense.Dispose();

			if (this.Updatefreight != null)
				this.Updatefreight.Dispose();

			if (this.Updategroup != null)
				this.Updategroup.Dispose();

			if (this.Updateincome != null)
				this.Updateincome.Dispose();

			if (this.Updatelabel != null)
				this.Updatelabel.Dispose();

			if (this.Updateloan != null)
				this.Updateloan.Dispose();

			if (this.Updatelocation != null)
				this.Updatelocation.Dispose();

			if (this.Updatematerial != null)
				this.Updatematerial.Dispose();

			if (this.Updatemeasure != null)
				this.Updatemeasure.Dispose();

			if (this.Updatepayment != null)
				this.Updatepayment.Dispose();

			if (this.Updatepaymentsale != null)
				this.Updatepaymentsale.Dispose();

			if (this.Updatepm != null)
				this.Updatepm.Dispose();

			if (this.Updateproduct != null)
				this.Updateproduct.Dispose();

			if (this.Updatepurchase != null)
				this.Updatepurchase.Dispose();


		}

		#endregion
	}
}