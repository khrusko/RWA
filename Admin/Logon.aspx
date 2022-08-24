<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="Admin.Logon" %>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Login CroVilla</title>

</head>
<body>
	<form id="form1" runat="server">
		<div class="container">
			<div class="row d-flex justify-content-center align-items-center">
				<div class="col-12 col-md-8 col-lg-8 col-xl-5">
					<div class="card shadow-2-strong" style="border-radius: 1rem;">
						<div class="card-body p-5 text-start">

							<h3 class="mb-5 font-weight-bold text-center">Sign in</h3>
							<hr />
							<%--E-mail--%>
							<div class="form-outline">
								<label class="d-flex justify-content-lg-start" for="txtUserName">Username</label>
								<asp:RequiredFieldValidator ControlToValidate="txtUserName"	Display="Static" ErrorMessage="Obvezno" runat="server"	ID="RequiredFieldValidator1" ForeColor="Red" />
								<input id="txtUserName" type="text" runat="server" class="form-control form-control-lg" />

							</div>

							<%--Password--%>
							<div class="form-outline ">
								<label class="form-label" for="txtUserPass-2">Password</label>
								<asp:RequiredFieldValidator ControlToValidate="txtUserPass"
									Display="Static" ErrorMessage="Obvezno" runat="server"
									ID="RequiredFieldValidator2" ForeColor="Red" />
								<input id="txtUserPass" type="password" runat="server" class="form-control form-control-lg" />

							</div>

							<!-- Cookie -->
							<div class="form-check d-flex justify-content-start">
								<asp:CheckBox ID="chkPersistCookie" CssClass="form-check-input" runat="server" AutoPostBack="false" />
								<label class="form-check-label" for="chkPersistCookie">Remember me</label>
							</div>

							<hr class="" />
							<asp:LinkButton ID="lbLogin" runat="server" CssClass="btn btn-primary btn-lg btn-block" OnClick="lbLogin_Click">Login</asp:LinkButton>
							<asp:Label ID="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
						</div>
					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
