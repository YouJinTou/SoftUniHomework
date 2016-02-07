<?php
namespace SoftUni\Controllers;

class UsersController extends Controller{
    private function initLogin($user, $pass)
    {
        $userModel = new User();

        $userId = $userModel->login($user, $pass);
        $_SESSION['id'] = $userId;
        header("Location: profile");
    }

    public function register()
    {
        $viewModel = new RegisterInformation();

        if (isset($_POST['username'], $_POST['password'])) {
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $userModel = new User();
                $userModel->register($user, $pass);

                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View();
    }
    
    public function login()
    {
        $viewModel = new LoginInformation();

        if (isset($_POST['username'], $_POST['password'])) {
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }
    
    public function profile(){
        // TODO
    }
    
    public function buildings(){
        // TODO
    }
}
