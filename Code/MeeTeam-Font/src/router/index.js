import Vue from 'vue'
import Router from 'vue-router'


Vue.use(Router)

//导入需要的组件
import LogIn from '@/view/Login.vue'
import InforList from '@/view/InforList.vue'
import PostInfor from '@/view/PostInfor.vue'
import CreatList from '@/view/CreatList.vue'
import MyProject from '@/view/MyProject.vue'
import AddUser from '@/view/AddUser.vue'
import AdminPage from '@/view/AdminPage.vue'
import NoticeList from '@/view/NoticeList.vue'
import RequireDetail from '@/view/RequireDetail.vue'
import ChangeList from '@/view/ChangeList.vue'
export default new Router({
    //在这里声明路由规则
    routes: [
        { path: '/', redirect: '/login' },
        { path: '/login', component: LogIn },
        { path: '/users/InforList', name: 'InforList', component: InforList, props: true },
        { path: '/users/RequireDetail', name: 'RequireDetail', component: RequireDetail, props: true },
        { path: '/users/PostInfor', component: PostInfor },
        { path: '/users/CreatList', component: CreatList },
        { path: '/users/MyProject', name: 'MyProject', component: MyProject, props: true },
        { path: '/users/ChangeList', name: 'ChangeList', component: ChangeList, props: true },
        { path: '/users/AddUser', component: AddUser },
        { path: '/Admin/AdminPage', component: AdminPage },
        { path: '/Admin/NoticeList', component: NoticeList },
    ],
})