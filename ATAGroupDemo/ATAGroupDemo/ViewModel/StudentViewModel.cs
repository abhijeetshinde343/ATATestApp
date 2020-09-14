using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ATAGroupDemo.Interface;
using ATAGroupDemo.Model;
using ATAGroupDemo.Services;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace ATAGroupDemo.ViewModel
{
    public class StudentViewModel: BaseViewModel
    {
        public ICommand RegisterCommand { get; set; }
        public ICommand PanCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        
        private String studentclass;
        public String StudentClass
        {
            get
            {
                return studentclass;
            }
            set
            {
                studentclass = value;
                OnPropertyChanged("StudentClass");
            }
        }
        private String username;
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private bool ismale;
        public bool IsMale
        {
            get
            {
                return ismale;
            }
            set
            {
                ismale = value;
                OnPropertyChanged("IsMale");
            }
        }

        private bool isfemale;
        public bool IsFemale
        {
            get
            {
                return isfemale;
            }
            set
            {
                isfemale = value;
                OnPropertyChanged("IsFemale");
            }
        }

        private String number;
        public String Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private String email;
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private String postalCode;
        public String PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        private String country;
        public String Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        private String state;
        public String State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        private String _ButtonName;
        public String ButtonName
        {
            get
            {
                return _ButtonName;
            }
            set
            {
                _ButtonName = value;
                OnPropertyChanged("ButtonName");
            }
        }
        
        private String city;
        public String City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        private String street;
        public String Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }
        private String _DocumentName;
        public String DocumentName
        {
            get
            {
                return _DocumentName;
            }
            set
            {
                _DocumentName = value;
                OnPropertyChanged("DocumentName");
            }
        }
        private DateTime _DOB;
        public DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
                OnPropertyChanged("DOB");
            }
        }
        public StudentTable _StudentTable { get; set; }
        public StudentViewModel(StudentTable studentTable)
        {
            _StudentTable = studentTable;
            this.Username = studentTable?.StudentName;
            if (studentTable?.StudentGender.ToLower() == "male")
                this.IsMale = true;
            else
                this.IsFemale = true;
            this.StudentClass = studentTable?.StudentClass;
            if(studentTable.AddressID!=0)
            {
                GetAddressData(studentTable.AddressID);
            }

            if (studentTable.DocumentID != 0)
            {
                GetDocumentData(studentTable.DocumentID);
            }
            this.Email = studentTable?.StudentEmail;
            this.Number = studentTable?.StudentContact;
            DocumentName = "Upload Document to Click";
            RegisterCommand = new Command(ExceuteRegisterCommand);
            PanCommand = new Command(ExecutePanCommand);
            if (Settings.Role == "admin")
                ButtonName = "Audit";
            else
                ButtonName = "Update";
        }

        private async void GetDocumentData(int documentID)
        {
            DocumentService documentService = new DocumentService();
            var data = await documentService.GetDocument(documentID);
            if(data!=null)
                this.DocumentName = data.Base64String;

        }

        private async void GetAddressData(int  AddressID)
        {
            AddressService addressService = new AddressService();
            var data = await addressService.GetAddress(AddressID);
            if (data != null)
            {
                this.City = data.City;
                this.Street = data.Street;
                this.PostalCode = data.PostCode;
                this.country = data.Country;
                this.State = data.State;
            }

        }

        

        private void ExecutePanCommand(object obj)
        {
            Cameraclick();
        }

        private async Task Cameraclick()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                var status1 = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        await Application.Current.MainPage.DisplayAlert("Need Camera ", "Need Camera Permision to enable function", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Camera))
                        status = results[Permission.Camera];
                }
                if (status1 != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    {
                        await Application.Current.MainPage.DisplayAlert("Need Storage ", "Need Storage Permision to enable function", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Storage))
                        status1 = results[Permission.Storage];
                }

                if (status == PermissionStatus.Granted || status1 == PermissionStatus.Granted)
                {

                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                      await Application.Current.MainPage. DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg"
                    });
                    DocumentName = file.Path;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await Application.Current.MainPage.DisplayAlert("Need Camera ", "Need Camera Permision to enable function", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Need Camera ", "Need Camera Permision to enable function", "OK");
               
            }
        }

        private async void ExceuteRegisterCommand(object obj)
        {
            if (Settings.Role != "admin")
            {
                AddressService address = new AddressService();
                AddressTable addressdata = new AddressTable() { City = this.City, Country = this.Country, PostCode = this.PostalCode, State = this.State, Street = this.Street };
                await address.SaveAddress(addressdata);
                DocumentTable documentTable = new DocumentTable() { Base64String = this.DocumentName };
                DocumentService documentService = new DocumentService();
                await documentService.SaveDocument(documentTable);
                StudentTable studentTable = new StudentTable()
                {
                    AddressID = addressdata.AddressId,
                    DocumentID = documentTable.DocumentId,
                    ISAuditable = "false",
                    StudentClass = this.StudentClass,
                    StudentContact = this.Number,
                    StudentEmail = this.Email,
                    StudentGender = this.IsFemale == true ? "FeMale" : "Male",
                    StudentName = this.Username,
                    StudnetDOB = this.DOB.ToString(),
                    UserID=this._StudentTable.UserID
                };

                RegistrationService registrationService = new RegistrationService();
                registrationService.DeleteStudent(_StudentTable);
             var row= await  registrationService.SaveStudent(studentTable);
                if (row != 0)
                    await Application.Current.MainPage.DisplayAlert("Success", "Update SuccessFull", "Cancel");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", " Data Not Updated ", "Cancel");
            }
            else
            {
                //StudentTable studentTable = obj as StudentTable;
                RegistrationService registrationService = new RegistrationService();
               var row=await registrationService.UpdateStudent(_StudentTable);
                if (row != 0)
                    await Application.Current.MainPage.DisplayAlert("Success", "Audit update  SuccessFull", "Cancel");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", " Audit Not Updated ", "Cancel");


            }
        }
    }
}
