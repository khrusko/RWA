<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApartmentEditor.aspx.cs" Inherits="Admin.ApartmentEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h3 class="mb-3">Detalji apartmana: </h3>
	<table class="table-borderless">
		<tr>
			<td>
				<div class="form-group col-md-12">
					<label>Vlasnik</label>
					<asp:DropDownList ID="ddlApartmentOwner" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlApartmentOwner_SelectedIndexChanged" AutoPostBack="True" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
				</div>
			</td>
			<td>
				<div class="form-group col-md-12">
					<label>Status</label>
					<asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
				</div>
			</td>

			<td>
				<div class="col-md-12">
					<div class="col-md-12">
						<div class="form-group">
							<label>Odabir tagova</label>
							<asp:DropDownList
								ID="ddlTags"
								runat="server"
								CssClass="form-control"
								DataValueField="Id"
								DataTextField="Name"
								AutoPostBack="true"
								OnSelectedIndexChanged="ddlTags_SelectedIndexChanged">
							</asp:DropDownList>
						</div>
					</div>
				</div>
			</td>
		</tr>


		<tr>
			<td>
				<div class="form-group col-md-12">
					<label>Naziv</label>
					<asp:RequiredFieldValidator ControlToValidate="tbName" Display="Static" ErrorMessage="Obvezno" runat="server" ID="RequiredFieldValidator3" ForeColor="Red" />
					<asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
				</div>
			</td>
			<td>
				<div class="form-group col-md-12">
					<label>Naziv (Engleski)</label>
					<asp:TextBox ID="tbNameEng" runat="server" CssClass="form-control"></asp:TextBox>
				</div>
			</td>
			<td rowspan="5" style="padding: 50px">Tagovi:
				<asp:Repeater ID="repTags" runat="server">
					<HeaderTemplate>
						<ul class="list-group">
					</HeaderTemplate>
					<ItemTemplate>
						<li class="list-group-item">
							<asp:HiddenField runat="server" ID="hidTagId" Value='<%# Eval("ID")   %>' />
							<asp:Label runat="server" ID="txtTagName" Text='<%# Eval("Name") %>' />
							<asp:LinkButton runat="server" ID="btnDeleteTag" CssClass="btn" OnClick="btnDeleteTag_Click">
          <span class="glyphicon glyphicon-trash"></span>
							</asp:LinkButton>
						</li>
					</ItemTemplate>
					<FooterTemplate>
						</ul>
					</FooterTemplate>
				</asp:Repeater>
			</td>
		</tr>


		<tr>
			<td>
				<div class="form-group col-md-12">
					<label>Grad</label>
					<asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="True" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
				</div>


			</td>
			<td>
				<div class="form-group col-md-12">
					<label>Adresa</label>
					<asp:TextBox ID="tbAddress" runat="server" CssClass="form-control"></asp:TextBox>
				</div>
			</td>
		</tr>



		<tr>
			<td>
				<div class="form-group col-md-12">
					<label>Broj odraslih</label>
					<asp:TextBox ID="tbMaxAdults" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
				</div>
			</td>
			<td>
				<div class="form-group col-md-12">
					<label>Broj djece</label>
					<asp:TextBox ID="tbMaxChildren" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
				</div>
			</td>
		</tr>


		<tr>
			<td>
				<div class="form-group col-md-12">
					<label>Broj soba</label>
					<asp:TextBox ID="tbTotalRooms" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
				</div>
			</td>
			<td>
				<div class="form-group col-md-12">
					<label>Udaljenost od plaže</label>
					<asp:TextBox ID="tbBeachDistance" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
				</div>

			</td>
		</tr>
		<tr>
			<td>
				<div class="form-group col-md-12">
					<label>Cijena (€)</label>
					<asp:RequiredFieldValidator ControlToValidate="tbPrice" Display="Static" ErrorMessage="Obvezno" runat="server" ID="RequiredFieldValidator5" ForeColor="Red" />

					<div class="input-group">
						<asp:TextBox ID="tbPrice" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
					</div>
				</div>
			</td>
		</tr>
	</table>




	<div class="container">
						Dodavanje slika: 
				<br />
		<div class="form-group">
			<label class="btn btn-default">

                <asp:FileUpload ID="uplImages" runat="server" CssClass="hidden" AllowMultiple="true" OnChange="handleFileSelect(this.files)" />
			</label>
			<div id="uplImageInfo"></div>
			<script>
				function handleFileSelect(files) {
					for (var i = 0; i < files.length; i++) {
						$span = $("<span class='label label-info'></span>").text(files[i].name);
						$('#uplImageInfo').append($span);
						$('#uplImageInfo').append("<br />");
					}
				}
			</script>
		</div>
	</div>

	<asp:Repeater ID="repApartmentPictures" runat="server">
		<ItemTemplate>
			<div class="form-group">
				<div class="row">
					<asp:HiddenField runat="server" ID="hidApartmentPictureId" Value='<%# Eval("ID") %>' />
					<div class="col-md-3">
						<a href="<%# Eval("Path") %>">
							<asp:Image ID="imgApartmentPicture" runat="server" CssClass="img-thumbnail" ImageUrl='<%# Eval("Path") %>' Width="320" Height="200" />
						</a>
					</div>
					<div class="col-md-3">
						<div class="form-group">
							<asp:TextBox ID="txtApartmentPicture" runat="server" CssClass="form-control" Text='<%# Eval("Name") %>' placeholder="Naziv" />
						</div>
						<div class="form-group">
							<label class="btn btn-success">
								Glavna slika
                              <asp:CheckBox ID="cbIsRepresentative" runat="server" CssClass="is-representative-picture" Checked='<%# Eval("IsRepresentative") %>' />
							</label>
						</div>
						<div class="form-group">
							<label class="btn btn-danger">
								<span class="text-white">Izbriši?</span>
								<asp:CheckBox ID="cbDelete" runat="server" Checked="false" />
							</label>
						</div>
					</div>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
	<script>
		$(function () {
			var repPicCheckboxes = $(".is-representative-picture > input[type=checkbox]");

			repPicCheckboxes.change(function () {
				currentCheckbox = this;
				if (currentCheckbox.checked) {
					repPicCheckboxes.each(function () {
						otherCheckbox = this
						if (currentCheckbox != otherCheckbox && otherCheckbox.checked) {
							otherCheckbox.checked = false;
						}
					})
				}
			});
		})
	</script>
	<hr />
	<span class="col-md-6">
		<asp:LinkButton ID="lblSave" runat="server" Text="Spremi" CssClass="btn btn-primary" OnClick="lblSave_Click" />
		<asp:LinkButton ID="lblBack" runat="server" Text="Odustani" CssClass="btn btn-secondary" OnClick="lblBack_Click" CausesValidation="false" />
	</span>

</asp:Content>
